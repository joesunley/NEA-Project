using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upload_Multiplayer_Results
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static ResultsFile UploadMultiplayerResults(Competition comp)
        {
            ResultsFile results = new ResultsFile();


            List<Player> allPlayers = new List<Player>();

            Console.Write("Enter the current round: ");
            int roundNum = Convert.ToInt16(Console.ReadLine());

            allPlayers = comp.rounds[roundNum].StartingCompetitors;

            Console.Write("Enter the number of competitors in the race: ");
            int numCompetitors = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < numCompetitors; i++)
            {
                Console.Write("Enter the name of the person in position " + (i + 1) + ": ");
                string name = Console.ReadLine();

                bool found = false;

                for (int j = 0; j < allPlayers.Count; j++)
                {
                    if (allPlayers[j].Name == name)
                    {
                        Console.Write("Enter the persons time in the format (mm:ss): ");
                        string time = Console.ReadLine();

                        results.AddResult(i, allPlayers[j], time);

                        found = true;
                        break;
                    }
                }

                if (found == true) { }
                else
                {
                    Console.WriteLine("Person not found: please try again.");
                    i -= 1;
                }
            }



            return new ResultsFile();
        }
    }
}
