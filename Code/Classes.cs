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
    public SpRace()
    {

    }

}

public class MpRace : IRace
{


    protected Host host;
    protected string ipAddress;



    protected Host host;
    protected string ipAddress;
    protected string raceName;
    protected string startInterval;
    protected string weather;
    protected bool NightMode;

    protected ResultsFile resultsFile;
    protected Map map;


    public MpRace()
    {

    }
}

public class CpRace : IRace
{

    protected string CompID;

    public CpRace()
    {

    }
}

public class Player
{
    protected int iD;
    protected string name;
    protected string email;
    protected string club;
    protected string cfUsername;
    protected string username;

    public Player()
    {

    }
}

public class Host : Player
{
    protected string iPAddress;

    public Host() : base(Player)
    {

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