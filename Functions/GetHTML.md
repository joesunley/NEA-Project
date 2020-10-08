# Get HTML

### Overview

This function gets the **raw** html from the inputted url : `string URL`. This html code is then returned as a string.

### Code
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

The code was sourced from: [Vb.net-Informations](http://vb.net-informations.com/communications/vb.net_read_url.htm). And was modified & converted to c# by me.
### Testing

#### Tests

Only one test was used : `https://www.autohotkey.com/docs/KeyList.htm`

#### Screenshots

##### Console Output

![](https://raw.githubusercontent.com/joesunley/NEA-Project/master/Resources/GetHTML%20Testing%20Screenshot%201.png)


##### Browser Output

![](https://raw.githubusercontent.com/joesunley/NEA-Project/master/Resources/GetHTML%20Testing%20Screenshot%202.png)
