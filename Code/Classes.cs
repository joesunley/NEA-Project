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
    public Group()
    {

    }
}

public class Race
{
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
    public MpRace() : base(Race)
    {

    }
}

public class CpRace : Race
{
    public CpRace() : base(Race)
    {

    }
}

public class Player
{
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
