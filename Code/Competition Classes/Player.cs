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
