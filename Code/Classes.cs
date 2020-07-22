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

    protected List<Race> Races = new List<Race>();

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

    /// <summary>
    /// Constructor Function for a Competition Race
    /// </summary>
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

    /// <summary>
    /// Constructor Function for a Player
    /// </summary>
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

    /// <summary>
    /// Constructor Function for a Host
    /// </summary>
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

    /// <summary>
    /// Constructor Function for a Host that uses a already existing Person
    /// </summary>
    /// <param name="player">A Player that has previously been created</param>
    /// <param name="ip">The Host's IP Address</param>
    public Host(Player player, string ip)
    {
        // ADD Player Details (properties)

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