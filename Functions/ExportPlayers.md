# Export Players

### Overview

This function takes a List of `Player`'s and coverts it to a string array

The array is structured as such: `Name, Email, Club, CF Username`
### Code

[Code File](https://github.com/joesunley/NEA-Project/blob/master/Resources/Code%20Files/Functions/ExportPlayers.cs)

```csharp
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
```
### Testing

#### Tests

#### Screenshots
