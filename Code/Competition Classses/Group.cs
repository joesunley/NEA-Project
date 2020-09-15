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

public class Group
{
    protected List<Player> competitors = new List<Player>();
    protected List<IRace> races = new List<IRace>(); // Inherited from the Round

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
