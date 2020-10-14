# Create Player

### Overview

The first part of this project takes a Competition class and exports it to a text? file
The second part takes in a text? file and converts it to a Competition class

The structure for the text file is:
```
Competition, name, numRounds
Round, ID, numGroups, numRaces, {Races(Id)}
Race, Id, Type, name, weather, nightMode, mapLoc, ip, sI, compId
```

And some sample data that will be used for testing is:
```
Competiton, MyComp, 3
Round, 0, 4, 3, {0 1 2}
Round, 1, 2, 2, {4, 5}
Round, 2, 1, 1, {3}
Race, 0, Sp, Dumyat, Sunny, No, somefile, na, na, na
Race, 1, Cp, Stirling, Sunny, no, somefile, na, na, 1536
Race, 2
Race, 3, Mp, Circuit Board, Rainy, yes, somefile, 128.0.12.3, MS, na
Race, 4
Race, 5
```

### Code

``` c sharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace Competition_Import___Export
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateImport("TestFile.txt");
        }

        static string[] CreateExport(Competition comp)
        {
            return new string[2];
        }

        static Competition CreateImport(string fileLoc)
        {
            Competition comp = new Competition();

            string[] import = File.ReadAllLines(fileLoc);

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
                CpRace race = new CpRace(line[9]);

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
