using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Competition
{
    public List<Round> rounds = new List<Round>();
    protected string compName;


    public Competition()
    {

    }

    public string Name
    {
        get
        {
            return this.compName;
        }

        set
        {
            this.compName = value;
        }
    }

    /// <summary>
    /// Add blank rounds after creating the competition
    /// </summary>
    /// <param name="_count">The number of rounds to create</param>
    public void AddRounds(int _count)
    {
        for (int i = 0; i < _count; i += 1) { rounds.Add(new Round()); }
    }

    public List<IRace> GetRaces()
    {
        List<IRace> races = new List<IRace>();

        for (int i = 0; i < rounds.Count; i++)
        {
            races.AddRange(rounds[i].GetRaces());
        }

        return races;
    }
}

public class Round
{
    public List<Group> groups = new List<Group>();
    protected List<IRace> races = new List<IRace>();

    protected List<Player> startingCompetitors = new List<Player>();
    protected List<Player> qualifiedCompetitors = new List<Player>();


    /// <summary>
    /// Blank Constructor Function for a Round
    /// </summary>
    public Round()
    {

    }

    /// <summary>
    /// Constructor function for a Round : accepts an already created list of groups
    /// </summary>
    /// <param name="group">The groups that will be created</param>
    /// <param name="race">The races that will be run by competitors</param>
    /// <param name="competitors">The list of competitors taking part</param>
    public Round(List<Group> group, List<IRace> race, List<Player> competitors)
    {
        this.groups = group;
        this.races = race;
        this.startingCompetitors = competitors;
    }

    /// <summary>
    /// Constructor function for a round : Takes in a number of groups and creates that many blank groups
    /// </summary>
    /// <param name="groupCount">The number of groups to be created</param>
    /// <param name="race">The races that will be run by competitors</param>
    /// <param name="competitors">The list of competitors taking part</param>
    public Round(int groupCount, List<IRace> race, List<Player> competitors)
    {
        for (int i = 0; i < groupCount; i += 1) { this.groups.Add(new Group()); }

        this.races = race;

        this.startingCompetitors = competitors;
    }

    /// <summary>
    /// Takes the list of competitors and shuffles that list and then splits it into the correct number of groups // Still need to add functionality for what happens once it has split the players
    /// </summary>
    private void CreateRandomGroups()
    {

        List<Player> competitors = Randomise(this.startingCompetitors);

        List<List<Player>> groupedPlayers = new List<List<Player>>();

        int groupCount = this.groups.Count;
        int playerCount = competitors.Count;

        for (int i = 0; i < groupCount; i += 1)
        {

            groupedPlayers.Add(new List<Player>());
        }

        for (int i = 0; i < playerCount; i += 1)
        {
            for (int j = 0; j < groupCount; j += 1)
            {
                try
                {

                    groupedPlayers[j].Add(this.startingCompetitors[i]);
                    i += 1;
                }
                catch { } //Catches when finished

            }
        }
    }

    /// <summary>
    /// Takes an ordered list of players and shuffles the list so it is a random order
    /// </summary>
    /// <param name="names">The list of players</param>
    /// <returns></returns>
    private List<Player> Randomise(List<Player> names)
    {
        List<Player> shuffled = new List<Player>();

        Random rnd = new Random();
        rnd.Next();

        do
        {
            try
            {
                Player selected = names[rnd.Next(0, names.Count - 1)];
                shuffled.Add(selected);
                names.Remove(selected);
            }
            catch { }
        } while (names.Count != 0);

        return shuffled;
    }

    /// <summary>
    /// Create blank Groups after the creation of the round
    /// </summary>
    /// <param name="_count">The number of Groups to be created</param>
    public void AddGroups(int _count)
    {
        for (int i = 0; i < _count; i += 1) { groups.Add(new Group()); }
    }

    /// <summary>
    /// Add Races to the current round
    /// </summary>
    /// <param name="_races">The list of races to add</param>
    /// <param name="replace">Whether or not the races are replacing the current ones or being added to the end</param>
    public void AddRaces(List<IRace> _races, bool replace)
    {
        if (replace)
        {
            races = _races;
        }
        else
        {
            races.AddRange(_races);
        }
    }

    /// <summary>
    /// The public property for the qualifiedCompetitors List
    /// </summary>
    public List<Player> QualifiedCompetitors
    {
        get
        {
            return this.qualifiedCompetitors;
        }

        set
        {

        }
    }

    /// <summary>
    /// Updates the Races within the groups
    /// </summary>
    public void UpdateGroupRaces()
    {
        for (int i = 0; i < groups.Count; i++)
        {
            groups[i].races.Clear();
            groups[i].races.AddRange(this.races);
        }
    }

    /// <summary>
    /// Gets the number of Races in the round
    /// </summary>
    /// <returns></returns>
    public int RaceCount() { return races.Count; }

    public List<IRace> GetRaces() { return races; }
}

public class Group
{
    protected List<Player> competitors = new List<Player>();
    public List<IRace> races = new List<IRace>(); // Inherited from the Round

    /// <summary>
    /// Blank Constructor Function for a group
    /// </summary>
    public Group() { }

    /// <summary>
    /// Constructor Function for a group
    /// </summary>
    /// <param name="players">The players that are competiting in this group</param>
    /// <param name="races">The races that are in the round</param>
    public Group(List<Player> players, List<IRace> races)
    {
        this.competitors = players;
        this.races = races;
    }
}

public interface IRace { }

public class SpRace : IRace
{

    protected ResultsFile resultsFile = new ResultsFile();  // Auto Generated
    protected Map map = new Map();                  // Required

    protected string raceName;          // Optional
    protected string weather;           // Optional
    protected bool nightMode;           // optional

    public SpRace()
    {

    }

    public SpRace(string _rN, string _w, bool _nM)
    {
        this.raceName = _rN;
        this.weather = _w;
        this.nightMode = _nM;
    }

    public SpRace(string _rN, string _w, bool _nM, string _mL)
    {
        this.raceName = _rN;
        this.weather = _w;
        this.nightMode = _nM;

        this.map.AddMapLocation(_mL);
    }

}

public class MpRace : IRace
{


    protected Host host;                // Required (Auto Generated)
    protected IPAddress ipAddress;      // Required
    protected string raceName;          // Optional
    protected string startInterval;     // Optional
    protected string weather;           // Optional
    protected bool nightMode;           // Optional

    protected ResultsFile resultsFile = new ResultsFile();  // Auto Generated
    protected Map map = new Map();                          // Required

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
    /// <param name="m">The map for the race</param>
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

    public MpRace(string ip, string rN, string sI, string wT, bool night, string mL)
    {
        this.ipAddress = IPAddress.Parse(ip);
        this.raceName = rN;
        this.startInterval = sI;
        this.weather = wT;
        this.nightMode = night;
        this.map.AddMapLocation(mL);
    }


    /// <summary>
    /// Constructor Function for a MultiPlayer Race
    /// </summary>
    /// <param name="ip">The Host's ip Address</param>
    /// <param name="m">The map for the race</param>
    public MpRace(string ip, Map m)
    {
        this.ipAddress = IPAddress.Parse(ip);
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
    /// <summary>
    /// Checks that the supplied start interval is valid
    /// </summary>
    /// <param name="sI">the start interval to check</param>
    /// <returns></returns>
    private bool CheckStartInterval(string sI)
    {
        //Mass Start, 15, 30, 45, 60, 120

        if (sI.ToUpper() == "MS") { return true; }
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

        set { if (CheckWeather(value)) { this.weather = value.ToUpper(); } else { } }
    }
    /// <summary>
    /// Checks that the weather inputted is an acceptable cf weather
    /// </summary>
    /// <param name="weather"></param>
    /// <returns></returns>
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

public class CpRace : IRace
{

    protected string compID;        // Required
    protected ResultsFile results;  // Auto Generated

    /// <summary>
    /// Blank Constructor Function for a Competition Race
    /// </summary>
    public CpRace() { }

    /// <summary>Constructor Function for a Competition Race</summary>
    /// <param name="cID">The Catching Features Competition ID for this Race (Can be found on the CF Website</param>
    public CpRace(string cID) { this.CompID = cID; }

    /// <summary>
    /// The public property for this.compID : Will accept if it is a valid competition
    /// </summary>
    public string CompID
    {
        get { return this.compID; }

        set { if (CheckCompID(value)) { this.compID = value; } }
    }
    private bool CheckCompID(string value)
    {
        // Will Check the Catching Features servers for current competitions
        // Must be in the list to be accepted

        return true;
    }
}

public class Player
{
    protected string name;
    protected string email;
    protected string club;
    protected string username;


    /// <summary>
    /// Blank Constructor Function for a Player
    /// </summary>
    public Player() { }

    /// <summary>Constructor Function for a Player</summary>
    /// <param name="n">The Players name</param>
    /// <param name="e">The Players Email Address</param>
    /// <param name="cl">The Players Club</param>
    /// <param name="u">The Players Catching Features Username</param>
    public Player(string n, string e, string cl, string u)
    {
        this.name = n;
        this.email = e;
        this.club = cl;
        this.username = u;
    }

    /// <summary>
    /// Public property for the Player.name
    /// </summary>
    public string Name
    {
        get { return this.name; }

        set
        {
            if (CheckName(value)) { this.name = value; }
        }
    }

    /// <summary>
    /// Checks an inputted string to ensure that it is: > 1 characters, Contains at least 2 words, and only contains letters, space and hyphens
    /// Returns true if acceptable, false if not
    /// </summary>
    /// <param name="name">The name to be checked</param>
    /// <returns></returns>
    private bool CheckName(string name)
    {
        if (name.Length < 2) { return false; }

        string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz- ";

        string[] split;

        try { split = name.Split(' '); if (split.Length >= 2) { } else { return false; } }
        catch { return false; }

        for (int i = 0; i < name.Length; i += 1) { if (acceptedChars.Contains(name[i])) { } else { return false; } }

        return true;
    }

    /// <summary>
    /// Public property for Player.email
    /// </summary>
    public string Email
    {
        get { return this.email; }

        set
        {
            if (CheckEmail(value)) { this.email = value; } //CheckEmail doesn'tdo anything atm - will check for: ??? @ ??? . ???
        }
    }

    private bool CheckEmail(string email)
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
    } // https://github.com/joesunley/NEA-Project/blob/master/Functions/CheckEmail.md

    /// <summary>
    /// Public property for Player.club
    /// </summary>
    public string Club
    {
        get { return this.club; }

        set
        {
            if (value.Length != 0) { this.club = Club; } //Checks length is at least 1
        }
    }

    /// <summary>
    /// Public property for Player.username - No Set Value (yet)
    /// </summary>
    public string Username
    {
        get { return this.username; }

        set
        {
            //Check the CF website for current players in ranking. Must be in ranking to allow
        }
    }
}

public class Host : Player
{
    protected IPAddress iPAddress;

    /// <summary>
    /// Blank Constructor Function for a Host
    /// </summary>
    public Host() { }

    /// <summary>Constructor Function for a Host</summary>
    /// <param name="n">The Players name</param>
    /// <param name="e">The Players Email Address</param>
    /// <param name="cl">The Players Club</param>
    /// <param name="u">The Players Catching Features Username</param>
    /// <param name="ip">The Host's IP Address</param>
    public Host(string n, string e, string cl, string U, string ip)
    {
        this.name = n;
        this.email = e;
        this.club = cl;
        this.username = U;
        this.iPAddress = IPAddress.Parse(ip);
    }

    /// <summary>Constructor Function for a Host that uses a already existing Person</summary>
    /// <param name="player">A Player that has previously been created</param>
    /// <param name="ip">The Host's IP Address</param>
    public Host(Player player, string ip)
    {
        this.name = player.Name;
        this.email = player.Email;
        this.club = player.Club;
        this.username = player.Username;

        this.iPAddress = IPAddress.Parse(ip); ;

    }

    public string IpAddress
    {
        get { return this.iPAddress.ToString(); }

        set { try { this.iPAddress = IPAddress.Parse(value); } catch { } }
    }

    public string[] GetStringArr()
    {
        List<string> lStr = new List<string>();

        lStr.Add(this.name);
        lStr.Add(this.username);
        lStr.Add(this.email);
        lStr.Add(this.club);
        lStr.Add(this.iPAddress.ToString());

        return lStr.ToArray();
    }
    public bool CheckHost(Host host)
    {
        bool accepted = true;



        return accepted;
    } // To be completed
}

public class Map
{

    string hostFileLocation = ""; // Required

    string mapName = "";        // Optional
    string mapMapper = "";      // Optional
    string mapDescription = ""; // Optional


    public Map()
    {

    }

    public Map(string loc)
    {
        this.hostFileLocation = loc;
    }

    public Map(string loc, string mN, string mM, string mD)
    {
        this.mapName = mN;
        this.mapMapper = mM;
        this.mapDescription = mD;

        this.hostFileLocation = loc;
    }

    public bool CheckMap(Map map) { return true; }

    public void PrepareForSending() { }

    public void AddMapLocation(string _mapLoc)
    {
        this.hostFileLocation = _mapLoc;
    }
}

public class ResultsFile
{

    protected string[,] results; //position, personID

    public ResultsFile()
    {

    }
}
