# Check Email

### Overview
This code takes an inputted  string and checks whether it conforms to [email address standards](http://rumkin.com/software/email/rules.php).

The rules it checks for are :
* Contains only one @ symbol
* Contains the Domain least one period
* Checks the Domain does not contain any special characters
* Checks the local address starts with a letter
* Checks that there are not 2 special characters in a row


### Code

[Code File](https://github.com/joesunley/NEA-Project/blob/master/Resources/Code%20Files/Functions/CheckEmail.cs)

```csharp
private static bool CheckEmail(string email)
        {
            const string acceptableDomainChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
            const string acceptableStartChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string specialChars = "!#$%&'*+-/=?^_`.{|}~";

            string[] splitForAt; // Splits the text at the @ symbo

            try
            {
                splitForAt = email.Split('@');

                if (splitForAt.Length != 2) { return false; }
            }
            catch { return false; } // Does not contain '@' symbol

            string domain = splitForAt[1];

            if (domain.Contains('.')) { } else { return false; }

            for (int i = 0; i < domain.Length; i += 1)
            {
                if (acceptableDomainChars.Contains(domain[i])) { } else { return false; }
            }

            if (acceptableStartChars.Contains(email[0])) { } else { return false; }

            for (int i = 0; i < email.Length - 1; i += 1)
            {
                if (specialChars.Contains(email[i]))
                {
                    if (email[i + 1] == email[i]) { return false; }
                }
            }

            return true;
        }

```
### Testing

#### Tests

Test no. | Test Type | Input Data | Expected Output | Output | Pass?
---------|-----------|------------|-----------------|--------|------
1  |Normal|Fred@bloggs.co.uk|True|True| Yes
2  |Normal|Fred1@bloggs1.com|True|True| Yes
3  |Erroneous|1Fred@bloggs.co.uk|False|False| Yes
4  |Erroneous|Fr&&d@bloggs.co.uk|False|False| Yes
5  |Erroneous|Fred@Blo&gs.co.uk|False|False| Yes
6  |Null|*Nothing*|False|False| Yes
7  |Erroneous|Abcdefghijklmnop|False|False| Yes
8  |Erroneous|abc@abc|False|False| Yes

#### Screenshots
![](https://raw.githubusercontent.com/joesunley/NEA-Project/master/Resources/CheckEmail%20Testing%20Screenshots.png)
