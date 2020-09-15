public class CpRace : IRace
{

    protected string compID;
    protected ResultsFile results;

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
