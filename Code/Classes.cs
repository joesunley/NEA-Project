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

public class Race
{

    protected List<Player> Players = new List<Player>();
    protected string title;

    public Race()
    {

    }
}

public class SpRace : Race
{
    public SpRace() : base(Race)
    {

    }

}

public class MpRace : Race
{

    protected Host host;
    protected string ipAddress;

    public MpRace() : base(Race)
    {

    }
}

public class CpRace : Race
{

    protected string CompID;

    public CpRace() : base(Race)
    {

    }
}

public class Player
{

    protected string name;
    protected string username;

    public Player()
    {

    }
}

public class Host : Player
{
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
