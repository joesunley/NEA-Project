public string[] ExportPlayers(List<Player> players)
        {
            List<string> exportList = new List<string>();

            for (int i = 0; i < players.Count; i++)
            {
                Player thisPlayer = players[i];

                string line = ((thisPlayer.Name) + ","
                    + (thisPlayer.Email) + ","
                    + (thisPlayer.Club) + ","
                    + (thisPlayer.Username));

                exportList.Add(line);
            }

            return exportList.ToArray();
        }
