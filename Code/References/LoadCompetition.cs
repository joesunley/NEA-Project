using System;
using System.Collections.Generic;
using System.IO;

public class LoadCompetition
{
    public Competition LoadComp(string fileLocation)
    {
        string[] import = File.ReadAllLines(fileLocation);

        return CreateCompetition(import);
    }

    private Competition CreateCompetition(string[] import)
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
    private Competition CreateComp(string[] line)
    {
        Competition comp = new Competition();

        comp.Name = line[1];
        comp.AddRounds(Convert.ToInt16(line[2])); //May need validation

        return comp;
    }
    private Round CreateRound(string[] line)
    {
        Round round = new Round();

        round.AddGroups(Convert.ToInt16(line[2]));

        return round;
    }
    private IRace CreateRace(string[] line)
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
