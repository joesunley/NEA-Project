using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Competition
{
    public Competition()
    {

    }
}

public class Round
{
    public Round()
    {

    }
}

public class Group
{

    protected List<IRace> Races = new List<IRace>();

    public Group()
    {

    }
}

public interface IRace
{

    protected List<Player> Players = new List<Player>();
    protected string title;

    
}

public class SpRace : IRace
{

    protected ResultsFile resultsFile;
    protected Map map;

    public SpRace()
    {

    }

}

public class MpRace : IRace
{


    protected Host host;
    protected string ipAddress;

    protected string raceName;
    protected string startInterval;
    protected string weather;
    protected bool NightMode;

    protected ResultsFile resultsFile;
    protected Map map;

    /// <summary>
    /// Blank Constuctor Function for a MultiPlayer Race
    /// </summary>
    public MpRace()
    {

    }
    /// <summary>
    /// Contstructor Function for a MultiPlayer Race
    /// </summary>
    /// <param name="h">The Host for this race</param>
    /// <param name="ip">The Host's ip Address</param>
    /// <param name="rN">The name of the race</param>
    /// <param name="sI">The start interval: Mass Start, 15, 3[, 45, 60, 120</param>
    /// <param name="wT">The weather during the race: Sunny, Raining, Sunny</param>
    /// <param name="night">Whether the race is at night or not</param>
    /// <param name="m">The Map for the race</param>
    public MpRace(Host h, string ip, string rN, string sI, string wT, bool night, Map m)
    {
        this.host = h;
        this.ipAddress = ip;
        this.raceName = rN;
        this.startInterval = sI;
        this.weather = wT;
        this.NightMode = night;
        this.map = m;
    }
}

public class CpRace : IRace
{

    protected string CompID;

    /// <summary>
    /// Blank Constructor Function for a Competition Race
    /// </summary>
    public CpRace()
    {

    }

    /// <summary>Constructor Function for a Competition Race</summary>
    /// <param name="cID">The Catching Features Competition ID for this Race (Can be found on the CF Website</param>
    public CpRace(string cID) { this.CompID = cID; }
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
    public Player()
    {

    }

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

        set {
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

        try { split = name.Split(' '); if (split.Length >= 2) { } else { return false; } } catch { return false; }

        for (int i = 0; i < name.Length; i += 1) { if (acceptedChars.Contains(name[i])) { } else { return false; } }

        return true;
    }

    /// <summary>
    /// Public property for Player.email
    /// </summary>
    public string Email
    {
        get { return this.email; }

        set {
            if (CheckEmail(value)) { this.email = value; } //CheckEmail doesn'tdo anything atm - will check for: ??? @ ??? . ???
        }
    }

    private bool CheckEmail(string email) { }

    /// <summary>
    /// Public property for Player.club
    /// </summary>
    public string Club
    {
        get { return this.club; }

        set {
            if (value.Length != 0) { this.club = Club; } //Checks length is at least 1
        }
    }

    /// <summary>
    /// Public property for Player.username - No Set Value (yet)
    /// </summary>
    public string Username
    {
        get { return this.username; }

        set {
            //Check the CF website for current players in ranking. Must be in ranking to allow
        }
    }
}

public class Host : Player
{
    protected string iPAddress;

    /// <summary>
    /// Blank Constructor Function for a Host
    /// </summary>
    public Host()
    {
        
    }

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
        this.iPAddress = ip;
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

        this.iPAddress = ip;

    }
}

public class Map
{
    public Map()
    {

    }
}

public class ResultsFile
{

    protected string[,] results; //position, personID

    public ResultsFile()
    {

    }
}