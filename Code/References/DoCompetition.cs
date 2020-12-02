using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DoCompetition
{
    public void DoComp(Competition comp)
    {
        List<Player> startingPlayers = comp.startingPlayers; //Gets the initial list of players in the competition
        int numRounds = comp.rounds.Count; // the number of rounds in the competition

        for (int i = 0; i < numRounds; i++)
        {
            startingPlayers = DoRound(comp.rounds[i], startingPlayers, comp.QualifyingMode); //Does the round for each competition, and sets the output of that round to the next list of players
        }
    }

    private List<Player> DoRound(Round round, List<Player> startingPlayers, Qualifying qualifyingMode)
    {
        round.StartingCompetitors = startingPlayers; // sets the players for creating groups
        round.CreateRandomGroups(); // creates the groups

        int totalQual = round.NumberOfQualifyingPlayers; // gets the number of people that will move through to the next round
        int numRaces = round.RaceCount();
        int numGroups = round.groups.Count;
        List<ResultsFile> allResults = new List<ResultsFile>();
        List<Player> qualifiedPlayers = new List<Player>();

        SendRaceFiles(round, startingPlayers); // Sends the Race Files to the players

        for (int currRace = 0; currRace < numRaces; currRace++)
        {
            allResults.Add(GetRaceResults(round.races[currRace])); // Gets all the results for each race and adds them to a list of Results Files
        }

        int perGroup = Convert.ToInt16(Math.Ceiling((decimal)(totalQual / numGroups))); //Calculates the max number of people that will qualify per group

        List<Tuple<Player, double>> returnedPlayers = GetQualifiedPlayers(allResults, round.StartingCompetitors, perGroup, qualifyingMode); //Gets the qualifing players


        if (returnedPlayers.Count > totalQual) // Removes the excess players that may have been added
        {
            for (int i = 0; i < totalQual; i++)
            {
                qualifiedPlayers.Add(returnedPlayers[i].Item1); // The list is ordered so the players removed are the slowest
            }
        }

        return qualifiedPlayers;
    }


    private ResultsFile GetRaceResults(IRace race)
    {
        ResultsFile resultsFile = new ResultsFile();

        if (race is SpRace) // Works out the race type
        {
            resultsFile = GetSpResults((SpRace)race); //Gets the results file
        }
        else if (race is MpRace)
        {
            resultsFile = GetMpResults((MpRace)race);
        }
        else if (race is CpRace)
        {
            resultsFile = GetCpResults((CpRace)race);
        }

        return resultsFile;
    }

    private ResultsFile GetSpResults(SpRace race) { return new ResultsFile(); }
    private ResultsFile GetMpResults(MpRace race) { return new ResultsFile(); }
    private ResultsFile GetCpResults(CpRace race) { return new ResultsFile(); }


    private List<Tuple<Player, double>> GetQualifiedPlayers(List<ResultsFile> allResults, List<Player> startingPlayers, int perGroup, Qualifying qualifyingMode)
    {
        List<Player> outputPlayers = new List<Player>();
        Dictionary<Player, List<double>> tempDict = new Dictionary<Player, List<double>>();
        Dictionary<Player, double> finalDict = new Dictionary<Player, double>();
        Dictionary<Player, double> orderedFinalDict = new Dictionary<Player, double>();
        List<Tuple<Player, double>> output = new List<Tuple<Player, double>>();

        for (int i = 0; i < startingPlayers.Count; i++) { tempDict.Add(startingPlayers[i], new List<double>()); } //Adds the players to the dictionary ready for scores to be added

        for (int currRace = 0; currRace < allResults.Count; currRace++) // runs through each race
        {
            ResultsFile currentResults = allResults[currRace];
            Dictionary<int, Tuple<Player, string>> rawResults = currentResults.Results;
            Dictionary<Player, double> unSortedResults = new Dictionary<Player, double>();
            Dictionary<Player, double> sortedResults = new Dictionary<Player, double>();
            double winnersTime = 9999999; //Max Time

            for (int i = 0; i < rawResults.Count; i++) // runs through each results / player
            {
                Player currPlayer = rawResults[i].Item1;
                string currTime = rawResults[i].Item2;

                double time = ConvertTime(currTime); //converts the time to a decimal

                unSortedResults.Add(currPlayer, time); // adds the player & time to the results list

                if (time < winnersTime) { winnersTime = time; } // checks to see if the time is the current fastest and updates if necessary
            }

            sortedResults = unSortedResults.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value); // orders the results by time - i think !!!!!!!!!!

            switch (qualifyingMode)
            {
                case Qualifying.percentage:

                    foreach (KeyValuePair<Player, double> results in sortedResults)
                    {
                        double percent = (100 * ((results.Value) / (winnersTime))) - 100; // calculates the % behind the winner

                        tempDict[results.Key].Add(percent); // adds to the dictionary
                    }

                    break;

                case Qualifying.position:

                    int position = 0;

                    foreach (KeyValuePair<Player, double> result in sortedResults)
                    {
                        tempDict[result.Key].Add(position); // adds the position

                        position += 1; // increases the position
                    }

                    break;

                default: break;
            }
        }

        foreach (KeyValuePair<Player, List<double>> kP in tempDict)
        {
            List<double> scores = kP.Value;
            double finalScore = 0;

            foreach (double s in scores) { finalScore += s; } // calculates their final score (sums them)

            finalDict[kP.Key] = finalScore; // adds to the final dictionary
        }

        orderedFinalDict = finalDict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value); // orders the players based on time
        List<Tuple<Player, double>> listTupleTemp = new List<Tuple<Player, double>>(); // Didn't know what to name it :)

        foreach (KeyValuePair<Player, double> person in orderedFinalDict)
        {
            listTupleTemp.Add(new Tuple<Player, double>(person.Key, person.Value)); // adds to a list for using the for loop
        }

        for (int i = 0; i < perGroup; i++)
        {
            output.Add(listTupleTemp[i]); // adds the correct amount of people to the final list
        }

        return output;
    }

    private double ConvertTime(string input)
    {
        List<string> valueArr = new List<string>();

        if (input == "") { }
        else { valueArr = input.Split(':').ToList<string>(); }

        string hours = "", minutes = "", seconds = "";

        try
        {
            hours = valueArr[0];
            minutes = valueArr[1];
            seconds = valueArr[2];
        }
        catch { }

        double hrs, secs, total;

        try
        {
            hrs = Convert.ToDouble(hours) * 60;
            secs = Convert.ToDouble(seconds) / 60;

            total = hrs + secs + (Convert.ToDouble(minutes));
        }
        catch { total = 0; }

        return total;
    }

    private void SendRaceFiles(Round round, List<Player> players) { }
}