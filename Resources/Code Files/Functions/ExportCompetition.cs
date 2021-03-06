static string[] ExportCompetition(Competition comp)
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
