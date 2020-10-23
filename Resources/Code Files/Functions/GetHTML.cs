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
