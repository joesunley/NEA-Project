# First Combined Attempt

### Overview

The first project that attempts to combine all the functions and projects into one.
This version is a CLI interface

### Code

[Code File](https://github.com/joesunley/NEA-Project/blob/master/Resources/Code%20Files/Projects/FirstCombinedAttempt.cs)

``` csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Net;

namespace First_Combined_Attempt
{
    class Program
    {
        public static Competition thisCompetition = new Competition();

        static void Main(string[] args)
        {
            MainMenu();
        }

        #region Main Menu
        static void MainMenu()
        {
            while (true)
            {
                DisplayMainMenu();
                GetSelection();
            }
            
        }
        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Create a new Competition");
            Console.WriteLine("2. Load an existing Competition");
            Console.WriteLine("3. Connect Players to the competition");
            Console.WriteLine("4. Start the current Competition");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
        }
        static void GetSelection() 
        {
            Console.Write("Enter your Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateComp(); break;
                case "2": LoadComp(); break;
                case "3": AddPlayers(); break;
                case "4": StartComp(); break;
                case "5": Exit(); break;
                default: IncorrectInp(); break;
            }
        }

        static void CreateComp() { thisCompetition = CreateCompetition(); }
        static void LoadComp() 
        {
            Console.Clear();
            Console.Write("Enter the location for the Competition File: ");
            string fileLoc = Console.ReadLine();
            List<string> importList = new List<string>();
            bool ok = false;

            try
            {
                importList = new List<string>(File.ReadAllLines(fileLoc));
                ok = true;
            }
            catch
            {
                MessageBox.Show("Incorrect file Location. \n Please try again.");
                LoadComp();
            }

            if (ok == false) { }
            else
            {
                string[] import = importList.ToArray();
                thisCompetition = CreateImport(import);
            }
            
        }
        static void AddPlayers() { ConnectPlayers(); }
        static void StartComp() { }
        static void Exit() { Environment.Exit(0); }
        static void IncorrectInp() { MessageBox.Show("The value you entered was not valid, please try again."); MainMenu(); }
        #endregion

        #region Create Competition

        static Competition CreateCompetition()
        {
            Competition comp = new Competition();

            Console.Write("Enter the Title: ");
            string title = Console.ReadLine();
            comp.Name = title;

            Console.Write("Enter the number of Rounds: ");
            int numRounds = Convert.ToInt16(Console.ReadLine());
            comp.AddRounds(numRounds);

            for (int i = 0; i < numRounds; i++)
            {
                Console.Write("Enter the number of groups for Round " + (i + 1) + ": ");
                int numGroups = Convert.ToInt16(Console.ReadLine());

                comp.rounds[i].AddGroups(numGroups);
            }

            for (int i = 0; i < numRounds; i++)
            {
                Console.Write("Enter the number of races: ");
                int numRaces = Convert.ToInt16(Console.ReadLine());

                List<IRace> races = new List<IRace>();

                for (int j = 0; j < numRaces; j++)
                {
                    Console.WriteLine("1. Singleplayer Race");
                    Console.WriteLine("2. Multiplayer Race");
                    Console.WriteLine("3. Competition Race");
                    Console.WriteLine();
                    Console.Write("Enter the Race Type: ");
                    int raceType = Convert.ToInt16(Console.ReadLine());

                    if (raceType == 1)
                    {


                        string mapLoc = "";

                        Console.Write("Is the map zipped / compressed? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.Write("Enter the link to the file: ");
                            mapLoc = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Enter the link to the folder: ");
                            mapLoc = Console.ReadLine();

                            mapLoc = CreateZip(mapLoc);
                            
                        }



                        Console.Write("Enter the Race Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter the Weather: ");
                        string weather = Console.ReadLine();

                        bool nightMode;
                        Console.Write("Is the Race at night? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y") { nightMode = true; } else { nightMode = false; }

                        SpRace race = new SpRace(name, weather, nightMode, mapLoc);

                        races.Add(race);
                    }
                    else if (raceType == 2)
                    {
                        string mapLoc = "";

                        Console.Write("Is the map zipped / compressed? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.Write("Enter the link to the file: ");
                            mapLoc = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Enter the link to the folder: ");
                            mapLoc = Console.ReadLine();

                            mapLoc = CreateZip(mapLoc);
                        }

                        Console.Write("Enter the IP Address of the Race Host: ");
                        string ipAddress = Console.ReadLine();

                        Console.Write("Enter the Race Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter the Weather: ");
                        string weather = Console.ReadLine();

                        bool nightMode;
                        Console.Write("Is the Race at night? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y") { nightMode = true; } else { nightMode = false; }

                        Console.Write("Enter the Start Interval: ");
                        string startInterval = Console.ReadLine();

                        MpRace race = new MpRace(ipAddress, name, startInterval, weather, nightMode, mapLoc);

                        races.Add(race);
                    }
                    else if (raceType == 3)
                    {
                        string compID = "";

                        Console.Write("Do you know the Competition ID? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.Write("Enter the Competition ID: ");
                            compID = Console.ReadLine();
                        }
                        else
                        {
                            //Select from list
                        }

                        CpRace race = new CpRace(compID);

                        races.Add(race);
                    }

                    comp.rounds[i].AddRaces(races, true);
                    comp.rounds[i].UpdateGroupRaces();
                }
            }

            return comp;
        }
        static string CreateZip(string filePath)
        {
            bool slashAtEnd = false;
            if (filePath[filePath.Length - 1] == '\\') { slashAtEnd = true; } else { slashAtEnd = false; }

            string endPath = "";
            string startPath = filePath;

            if (slashAtEnd == true)
            {
                endPath = filePath.Substring(0, filePath.Length - 1);
                string[] split = endPath.Split('\\');
                endPath = "";
                
                for (int i = 0; i < split.Length - 1; i++) { endPath += split[i] + "\\"; }

                endPath += "result.zip";
            }

            if (slashAtEnd == false)
            {
                startPath += "\\";
            }

            ZipFile.CreateFromDirectory(startPath, endPath);

            return endPath;

        }

        #endregion

        #region Load Competition

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

        #endregion

        #region Add Players

        static void ConnectPlayers()
        {
            Console.WriteLine("For players to enter they should enter the IP Address: {0}", GetIP().ToString());
            List<Player> players = PlayersConnecting(GetIP());

            thisCompetition.AddStartingPlayers(players);
        }
        static IPAddress GetIP() { return IPAddress.Parse("255.0.0.1"); } // Will return the IP address of the machine
        static List<Player> PlayersConnecting(IPAddress thisIP)
        {
            // ConnectPlayers
            return new List<Player>();
        }

        #endregion

        #region Start Competition

        static void CompStart()
        {
            int numRounds = thisCompetition.rounds.Count;
            List<Player> startingPlayers = new List<Player>();


            for (int i = 0; i < numRounds; i++)
            {
                if (i == 0)
                {
                    startingPlayers = thisCompetition.startingPlayers;
                    startingPlayers = DoRound(i, startingPlayers);
                }
                else
                {
                    startingPlayers = DoRound(i, startingPlayers);
                }
            }
        }
        static List<Player> DoRound(int roundNum, List<Player> players)
        {
            thisCompetition.rounds[roundNum].StartingCompetitors = players;

            thisCompetition.rounds[roundNum].CreateRandomGroups();

            BroadcastGroups(roundNum);

            int numRaces = thisCompetition.rounds[roundNum].RaceCount();

            List<ResultsFile> results = new List<ResultsFile>();

            for (int i = 0; i < numRaces; i++)
            {
                results.Add(GetRaceResults(roundNum, i));
            }
            
            return new List<Player>();
        }
        static ResultsFile GetRaceResults(int roundNum, int raceNum)
        {
            ResultsFile thisResultsFile = new ResultsFile();

            IRace thisRace = thisCompetition.rounds[roundNum].races[raceNum];

            if (thisRace is SpRace)
            {
                thisResultsFile = AskForSpResults();

                SpRace thisSpRace = (SpRace)thisRace;
                thisSpRace.ResultsFile = thisResultsFile;

                thisCompetition.rounds[roundNum].races[raceNum] = thisSpRace;
            }
            else if (thisRace is MpRace)
            {
                thisResultsFile = GetMpResults();

                MpRace thisMpRace = (MpRace)thisRace;
                thisMpRace.ResultsFile = thisResultsFile;

                thisCompetition.rounds[roundNum].races[raceNum] = thisMpRace;
            }
            else if (thisRace is CpRace)
            {
                CpRace thisCpRace = (CpRace)thisRace;

                thisResultsFile = thisCpRace.GetResults();

                thisCpRace.ResultsFile = thisResultsFile;

                thisCompetition.rounds[roundNum].races[raceNum] = thisCpRace;
            }

            return thisResultsFile;
        }
        static List<Player> GetQualifiedPlayers(List<ResultsFile> results, int perGroup, Qualifying qual, int roundNum)
        {
            List<Player> outputPlayers = new List<Player>();

            Dictionary<Player, List<double>> tempDict = new Dictionary<Player, List<double>>();
            Dictionary<Player, double> finalDict = new Dictionary<Player, double>();
            List<Player> players = thisCompetition.rounds[roundNum].StartingCompetitors;

            for (int i = 0; i < players.Count; i++) { tempDict.Add(players[i], new List<double>()); }

            #region Switch Statement

            switch (qual)
            {
                case Qualifying.percentage:

                    for (int i = 0; i < results.Count; i++)
                    {
                        ResultsFile currentRace = results[i];
                        Dictionary<int, Tuple<Player, string>> rawResults = currentRace.GetResults();
                        Dictionary<Player, double> unSortedResults = new Dictionary<Player, double>();
                        Dictionary<Player, double> sortedResults = new Dictionary<Player, double>();
                        double winnersTime = 999999; //

                        for (int j = 0; j < rawResults.Count; j++)
                        {
                            Player currentPlayer = rawResults[j].Item1;
                            string currentTime = rawResults[j].Item2;
                            double time = ConvertTime(currentTime);

                            unSortedResults.Add(currentPlayer, time);
                            if (time < winnersTime) { winnersTime = time; }

                        }

                        sortedResults = unSortedResults.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                        Dictionary<Player, double> percentageResults = new Dictionary<Player, double>();

                        foreach (KeyValuePair<Player, double> result in sortedResults)
                        {
                            double percent = (100 * ((result.Value) / (winnersTime))) - 100;

                            tempDict[result.Key].Add(percent);
                        }

                    }

                    break;
                case Qualifying.position:
                    for (int i = 0; i < results.Count; i++)
                    {
                        ResultsFile currentRace = results[i];
                        Dictionary<int, Tuple<Player, string>> rawResults = currentRace.GetResults();
                        Dictionary<Player, double> unSortedResults = new Dictionary<Player, double>();
                        Dictionary<Player, double> sortedResults = new Dictionary<Player, double>();
                        double winnersTime = 999999; //

                        for (int j = 0; j < rawResults.Count; j++)
                        {
                            Player currentPlayer = rawResults[j].Item1;
                            string currentTime = rawResults[j].Item2;
                            double time = ConvertTime(currentTime);

                            unSortedResults.Add(currentPlayer, time);
                            if (time < winnersTime) { winnersTime = time; }

                        }

                        sortedResults = unSortedResults.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                        Dictionary<Player, double> scored = new Dictionary<Player, double>();

                        int count = 0;

                        foreach (KeyValuePair<Player, double> result in sortedResults)
                        {
                            tempDict[result.Key].Add(count);

                            count += 1;
                        }

                    }
                    break;
                default: break;
            }

            #endregion

            foreach (KeyValuePair<Player, List<double>> kP in tempDict)
            {
                List<double> scores = kP.Value;
                double finalScore = 0;

                foreach (double s in scores)
                {
                    finalScore += s;
                }

                finalDict[kP.Key] = finalScore;
            }

            List<Player> orderedPlayers = new List<Player>();

            foreach (KeyValuePair<Player, double> pers in finalDict)
            {
                orderedPlayers.Add(pers.Key);
            }

            for (int i = 0; i < perGroup; i++)
            {
                outputPlayers.Add(orderedPlayers[i]);
            }

            return outputPlayers;
        }

        static double ConvertTime(string input)
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
            catch { MessageBox.Show("Invalid Data"); }

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
        static ResultsFile GetMpResults() { return new ResultsFile(); }

        #endregion

        #region Communication

        //Send
        static void BroadcastToAllPlayers(object toBroadcast, int sendCode) { }
        static void BroadcastGroups(int roundNum)
        {
            List<string> output = new List<string>();

            Round thisRound = thisCompetition.rounds[roundNum];

            List<List<Player>> groupedPlayers = thisRound.GetGroupedPlayers();

            output.Add(("The groups for round " + (roundNum + 1) + " are as follows: "));

            for (int i = 0; i < groupedPlayers.Count; i++)
            {
                output.Add("Group " + (i + 1) + ":");

                for (int j = 0; j < groupedPlayers[i].Count; j++)
                {
                    output.Add(groupedPlayers[i][j].Name);
                }
            }

            BroadcastToAllPlayers(output, 0000); // Need to do sendCode's
        }

        static void BroadcastRace(int raceNum) { }

        //Receive
        static ResultsFile AskForSpResults() { return new ResultsFile(); }

        #endregion
    }
}
```
### Testing
