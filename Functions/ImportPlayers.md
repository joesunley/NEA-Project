# Import Players

### Overview

This function takes a string array and converts it to a list of `Player`'s.

The array is structured as such: `Name, Email, Club, CF Username`
### Code

```csharp
public List<Player> ImportPlayers(string[] import)
        {
            List<Player> players = new List<Player>();

            for (int i = 0; i < import.Length; i++)
            {
                string[] line = import[i].Split(','); //Name, email, club, CF username

                Player thisPlayer = new Player(line[0], line[1], line[2], line[3]);

                players.Add(thisPlayer);
            }
            
            return players;
        }
```
### Testing

#### Tests

#### Screenshots
