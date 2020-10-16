# Binary File Reader / Writer

### Overview

A project that takes the code for the [Competition Import + Export](https://github.com/joesunley/NEA-Project/blob/master/Projects/Competition%20Import%20%26%20Export.md) project and modifies it for creating a binary file

### Code

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binary_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw;
            BinaryReader br;

            Competition comp = CreateImport(File.ReadAllLines("TestFile.txt"));

            string[] output = CreateExport(comp);


            Encoding utf8 = Encoding.UTF8;
            bw = new BinaryWriter(new FileStream("mydata", FileMode.Create), utf8);

            for (int i = 0; i < output.Length; i++)
            {
                bw.Write(output[i]);
            }

            bw.Close();


            br = new BinaryReader(new FileStream("mydata", FileMode.Open), utf8);

            bool eof = false;
            List<string> input = new List<string>();

            do
            {
                try
                {
                    input.Add(br.ReadString());
                }
                catch
                {
                    eof = true;
                }
            } while (eof == false);
        }


        static string[] CreateExport(Competition comp)
        {

            List<string> outputList = new List<string>();

            string compLine = ("Competition," + (comp.Name) + "," + (comp.rounds.Count));

            outputList.Add(compLine);

            List<IRace> allRaces = comp.GetRaces();

            Dictionary<int, IRace> raceDict = new Dictionary<int, IRace>();

            for (int i = 0; i < allRaces.Count; i++) { raceDict.Add(i, allRaces[i]); }

            List<string> raceLines = ConvertRaces(raceDict);

            List<string> roundLines = ConvertRounds(comp, raceDict);

            outputList.AddRange(roundLines);
            outputList.AddRange(raceLines);

            string[] output = outputList.ToArray();

            return output;
        }

        static List<string> ConvertRaces(Dictionary<int, IRace> raceDict)
        {
            List<string> raceLines = new List<string>();

            for (int i = 0; i < raceDict.Count; i++)
            {

                string line = "";

                if (raceDict[i] is SpRace)
                {
                    SpRace race = (SpRace)raceDict[i];

                    line = ("Race," + i + ",Sp," + (race.Name) + ","
                        + race.Weather + ","
                        + (BooltoYN(race.NightMode)) + ","
                        + (race.Map.MapLocation)
                        + ",na,na,na");
                }
                else if (raceDict[i] is MpRace)
                {
                    MpRace race = (MpRace)raceDict[i];

                    line = ("Race," + i + ",Mp," + (race.Name) + ","
                        + race.Weather + ","
                        + (BooltoYN(race.NightMode)) + ","
                        + (race.Map.MapLocation) + ","
                        + race.IpAddress + ","
                        + race.StartInterval
                        + ",na");
                }
                else if (raceDict[i] is CpRace)
                {
                    CpRace race = (CpRace)raceDict[i];

                    line = ("Race," + i + ",Cp," + (race.Name) + ","
                        + "na,na,na,na,na,"
                        + race.CompID);
                }

                raceLines.Add(line);
            }

            return raceLines;
        }

        static List<string> ConvertRounds(Competition comp, Dictionary<int, IRace> raceDict)
        {
            List<string> rounds = new List<string>();


            for (int i = 0; i < comp.rounds.Count; i++)
            {
                List<int> raceIds = new List<int>();

                Round round = comp.rounds[i];
                List<IRace> races = round.GetRaces();

                #region Get nums
                for (int j = 0; j < round.RaceCount(); j++)
                {
                    for (int k = 0; k < raceDict.Count; k++)
                    {
                        if (races[j] == raceDict[k])
                        {
                            raceIds.Add(k);
                        }
                    }
                }
                #endregion

                string line = ("Round," + (i) + "," + (round.groups.Count) + "," + (round.RaceCount()) + ",{");



                for (int j = 0; j < raceIds.Count; j++)
                {
                    if (j != 0) { line += " "; }

                    line += ((raceIds[j].ToString()));
                }

                line += "}";

                rounds.Add(line);
            }

            return rounds;
        }

        static string BooltoYN(bool input)
        {
            if (input == true) { return "yes"; } else { return "no"; }
        }



        static Competition CreateImport(string[] import)
        {
            Competition comp = new Competition();

            List<IRace> races = new List<IRace>();
            List<string> racesStr = new List<string>();
            List<string> rounds = new List<string>();

            for (int i = 0; i < import.Length; i++)
            {
                string thisLine = import[i];
                string[] line = thisLine.Split(',');

                if (line[0] == "Competition")
                {
                    Competition updatedComp = CreateComp(line);

                    comp = updatedComp;
                }
                else if (line[0] == "Round")
                {
                    Round round = CreateRound(line);
                    comp.rounds[Convert.ToInt16(line[1])] = round;

                    rounds.Add(import[i]);
                }
                else if (line[0] == "Group")
                {

                }
                else if (line[0] == "Race")
                {
                    IRace race = CreateRace(line);
                    races.Add(race);
                    racesStr.Add(line[0]);
                }
            }

            for (int i = 0; i < comp.rounds.Count; i++)
            {

                string[] line = rounds[i].Split(',');
                string raceIds = line[4];

                comp.rounds[i].AddRaces(GetRacesforRound(raceIds, races), false);
                comp.rounds[i].UpdateGroupRaces();
            }

            return comp;
        }

        static Competition CreateComp(string[] line)
        {
            Competition comp = new Competition();

            comp.Name = line[1];
            comp.AddRounds(Convert.ToInt16(line[2])); //May need validation

            return comp;
        }

        static Round CreateRound(string[] line)
        {
            Round round = new Round();

            round.AddGroups(Convert.ToInt16(line[2]));

            return round;
        }

        static IRace CreateRace(string[] line)
        {
            if (line[2] == "Sp")
            {
                SpRace race = new SpRace(line[3], line[4], YNtoBoolean(line[5]), line[6]);

                return race;
            }
            else if (line[2] == "Mp")
            {
                MpRace race = new MpRace(line[7], line[3], line[8], line[4], YNtoBoolean(line[5]), line[6]);

                return race;
            }
            else if (line[2] == "Cp")
            {
                CpRace race = new CpRace(line[3], line[9]);

                return race;
            }
            else { return new SpRace(); } //Just to remove the error - cannot end up with this
        }

        static List<IRace> GetRacesforRound(string raceIds, List<IRace> allRaces)
        {
            raceIds = raceIds.Substring(1);
            raceIds = raceIds.Substring(0, raceIds.Length - 1);

            string[] iDs = raceIds.Split(' ');

            List<IRace> races = new List<IRace>();

            for (int i = 0; i < iDs.Length; i++)
            {
                races.Add(allRaces[Convert.ToInt16(iDs[i])]);
            }

            return races;

        }

        static bool YNtoBoolean(string input)
        {
            if (input.ToUpper() == "YES") { return true; } else { return false; }
        }

    }
}

```

### Testing
