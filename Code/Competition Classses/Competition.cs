public class Competition
{
    protected List<Round> rounds = new List<Round>();
    protected string compName;


    public Competition()
    {

    }

    /// <summary>
    /// Add blank rounds after creating the competition
    /// </summary>
    /// <param name="_count">The number of rounds to create</param>
    public void AddRounds(int _count)
    {
        for (int i = 0; i < _count; i += 1) { rounds.Add(new Round()); }
    }
}
