# Check Name


### Overview
This code is used to check whether an inputted name is acceptable for a `Player` or `Host`.
It checks for :
* A string that is longer than 2 characters
* Contains at least 2 words
* Only contains letters, spaces & hyphens

If those criteria are met then the program returns **True**, else it returns **False**

### Code

[Code File](https://github.com/joesunley/NEA-Project/blob/master/Resources/Code%20Files/Functions/CheckName.cs)

```csharp
private bool CheckName(string name)
    {
        if (name.Length < 2) { return false; }

        string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz- ";

        string[] split;

        try {
            split = name.Split(' ');
            if (split.Length >= 2) {
                //Do Nothing
            } else {
                return false;
            }
        } catch {
            return false;
        }

        for (int i = 0; i < name.Length; i += 1) {
            if (acceptedChars.Contains(name[i])) {
                //Do Nothing
            } else {
                return false;
            }
        }

        return true;
    }
```
### Testing

#### Tests
Test no. | Test Type | Input Data | Expected Output | Output | Pass?
---------|-----------|------------|-----------------|--------|------
1  |Normal|Joe Sunley|True|True| Yes
2  |Erroneous|JoeSunley|False|False| Yes
3  |Erroneous|Joe|False|False| Yes
4  |Erroneous|J|False|False| Yes
5  |Erroneous|Joe1 Sunley|False|False| Yes
6  |Erroneous|Joe Sunley&^$67|False|False| Yes
7  |Normal|Joe Sunley-Smith|True|True| Yes
8  |Normal|Joe Sunley Smith|True|True| Yes
9  |Erroneous|Jo|False|False| Yes
10 |Boundary|Jo Sunley|True|True| Yes
#### Screenshots
![CheckName Testing Screenshots](https://raw.githubusercontent.com/joesunley/NEA-Project/master/Resources/CheckName%20Testing%20Screenshots.png)
