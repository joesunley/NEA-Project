public class MpRace : IRace
{


    protected Host host;
    protected IPAddress ipAddress;
    protected string raceName;
    protected string startInterval;
    protected string weather;
    protected bool nightMode;

    protected ResultsFile resultsFile;
    protected Map map;

    /// <summary>
    /// Blank Constuctor Function for a MultiPlayer Race
    /// </summary>
    public MpRace() { }

    /// <summary>
    /// Contstructor Function for a MultiPlayer Race
    /// </summary>
    /// <param name="h">The Host for this race</param>
    /// <param name="ip">The Host's ip Address</param>
    /// <param name="rN">The name of the race</param>
    /// <param name="sI">The start interval: Mass Start, 15, 30, 45, 60, 120</param>
    /// <param name="wT">The weather during the race: Sunny, Raining, Snowing</param>
    /// <param name="night">Whether the race is at night or not</param>
    /// <param name="m">The Map for the race</param>
    public MpRace(Host h, string ip, string rN, string sI, string wT, bool night, Map m)
    {
        this.host = h;
        this.ipAddress = IPAddress.Parse(ip);
        this.raceName = rN;
        this.startInterval = sI;
        this.weather = wT;
        this.nightMode = night;
        this.map = m;
    }

    /// <summary>
    /// The public property for MpRace.ipAddress : Will accept if the inputted string is the correct format for an IpAddress
    /// </summary>
    public string IpAddress
    {
        get { return this.ipAddress.ToString(); }

        set { try { this.ipAddress = IPAddress.Parse(value); } catch { } }
    }

    /// <summary>
    /// The public property for MpRace.host : Will accept if the input is an acceptable host
    /// </summary>
    public Host Host
    {
        get { return host; }

        set
        {
            if (Host.CheckHost(value))
            {
                this.host = value;
                this.ipAddress = IPAddress.Parse(value.IpAddress);// IpAddress Property in Host Class
            }
            else
            {
                // Return Error
            }
        }
    }

    /// <summary>
    /// The public property for MpRace.raceName : Will accept if it is not an empty string
    /// </summary>
    public string RaceName
    {
        get { return this.raceName; }

        set { if (value.Length > 0) { this.raceName = value; } else { } }
    }

    /// <summary>
    /// The public property for MpRace.startInterval : Will accept if it if a start interval accepted by cf
    /// </summary>
    public string StartInterval
    {
        get { return this.startInterval; }

        set { if (CheckStartInterval(value)) { this.startInterval = value; } else { } }
    }
    private bool CheckStartInterval(string sI)
    {
        //Mass Start, 15, 30, 45, 60, 120

        if (sI == "MS") { return true; }
        else if (sI == "30") { return true; }
        else if (sI == "45") { return true; }
        else if (sI == "60") { return true; }
        else if (sI == "120") { return true; }
        else { return false; }
    }

    /// <summary>
    /// The public property for MpRace.weather : Will accept if it is an accepted weather for cf
    /// </summary>
    public string Weather
    {
        get { return this.weather; }

        set { if (CheckWeather(value)) { this.weather = value; } else { } }
    }
    private bool CheckWeather(string weather)
    {
        if (weather.ToUpper() == "SUNNY") { return true; }
        else if (weather.ToUpper() == "RAINING") { return true; }
        else if (weather.ToUpper() == "SNOWING") { return true; }
        else { return false; }
    }

    /// <summary>
    /// The public property for MpRace.nightMode : Does not require any validation
    /// </summary>
    public bool NightMode
    {
        get { return this.nightMode; }

        set { this.nightMode = value; }
    }

    /// <summary>
    /// The public property for MpRace.map : Accepts if it as an acceptable map
    /// </summary>
    public Map Map
    {
        get { return this.map; }

        set { if (Map.CheckMap(value)) { this.map = value; } else { } }
    }
}
