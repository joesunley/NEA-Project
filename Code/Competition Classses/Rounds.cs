public class Round
{
    protected List<Group> groups = new List<Group>();
    protected List<IRace> races = new List<IRace>();

    protected List<Player> startingCompetitors = new List<Player>();
    protected List<Player> qualifiedCompetitors = new List<Player>();


    /// <summary>
    /// Blank Constructor Function for a Round
    /// </summary>
    public Round()
    {

    }

    /// <summary>
    /// Constructor function for a Round : accepts an already created list of groups
    /// </summary>
    /// <param name="group">The groups that will be created</param>
    /// <param name="race">The races that will be run by competitors</param>
    /// <param name="competitors">The list of competitors taking part</param>
    public Round(List<Group> group, List<IRace> race, List<Player> competitors)
    {
        this.groups = group;
        this.races = race;
        this.startingCompetitors = competitors;
    }

    /// <summary>
    /// Constructor function for a round : Takes in a number of groups and creates that many blank groups
    /// </summary>
    /// <param name="groupCount">The number of groups to be created</param>
    /// <param name="race">The races that will be run by competitors</param>
    /// <param name="competitors">The list of competitors taking part</param>
    public Round(int groupCount, List<IRace> race, List<Player> competitors)
    {
        for (int i = 0; i < groupCount; i += 1) { this.groups.Add(new Group()); }

        this.races = race;

        this.startingCompetitors = competitors;
    }

    private void CreateRandomGroups()
    {

        List<Player> competitors = Randomise(this.startingCompetitors);

        List<List<Player>> groupedPlayers = new List<List<Player>>();

        int groupCount = this.groups.Count;
        int playerCount = competitors.Count;

        for (int i = 0; i < groupCount; i += 1)
        {

            groupedPlayers.Add(new List<Player>());
        }

        for (int i = 0; i < playerCount; i += 1)
        {
            for (int j = 0; j < groupCount; j += 1)
            {
                try
                {

                    groupedPlayers[j].Add(this.startingCompetitors[i]);
                    i += 1;
                }
                catch { } //Catches when finished

            }
        }
    }

    private List<Player> Randomise(List<Player> names)
    {
        List<Player> shuffled = new List<Player>();

        Random rnd = new Random();
        rnd.Next();

        do
        {
            try
            {
                Player selected = names[rnd.Next(0, names.Count - 1)];
                shuffled.Add(selected);
                names.Remove(selected);
            }
            catch { }
        } while (names.Count != 0);

        return shuffled;
    }

    /// <summary>
    /// Create blank Groups after the creation of the round
    /// </summary>
    /// <param name="_count">The number of Groups to be created</param>
    public void AddGroups(int _count)
    {
        for (int i = 0; i < _count; i += 1) { groups.Add(new Group()); }
    }
}
