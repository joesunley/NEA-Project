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
