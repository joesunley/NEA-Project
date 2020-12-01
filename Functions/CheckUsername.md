# Check Username

### Overview
This code is designed to check whether the Catching Features username the user has inputted is an active account.
> An account is considered active if it appears on the Catching Features [Ranking Page](http://www.catchingfeatures.com/comps/rankings.php)

If the username is found to be active the program returns **True** else it will return **False**.

This check will be used in the `Player` or `Host` classes.



### Code

``` 
Code goes here when done
```

The Code uses the [GetHTML](https://github.com/joesunley/NEA-Project/blob/master/Functions/GetHTML.md) Function, in order to get the contents of the ranking page.

``` csharp
using System.IO;
using System.Net;

public string GetHTML(string URL)
{
    StreamReader instream;
    WebRequest webrequest;
    WebResponse webresponse;

    webrequest = WebRequest.Create(URL);
    webresponse = webrequest.GetResponse();
    instream = new StreamReader(webresponse.GetResponseStream());

    return instream.ReadToEnd().ToString();
}
```
### Testing

#### Tests

| Test No. | Test Type | Input Data           | Expected Output | Output | Pass |
|----------|-----------|----------------------|-----------------|--------|------|
| 1        | Normal    | joesunley            | True            |        |      |
| 2        | Edge      | (°ç°)                | True            |        |      |
| 3        | Normal    | Gusten Grodslukare   | True            |        |      |
| 4        | Null      | *Nothing*            | False           |        |      |
| 5        | Erroneous | abcdefghijkmnop      | False           |        |      |
| 6        | Erroneous | @dk.3k.753dfghk-sef  | False           |        |      |

#### Screenshots
