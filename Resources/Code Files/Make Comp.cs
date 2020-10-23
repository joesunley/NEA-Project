using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_Comp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateComp();
        }

        static void CreateComp()
        {
            Competition comp = new Competition();

            Console.Write("Enter the Title: ");
            string title = Console.ReadLine();
            comp.Name = title;

            Console.Write("Enter the number of Rounds: ");
            int numRounds = Convert.ToInt16(Console.ReadLine());
            comp.AddRounds(numRounds);

            for (int i = 0; i < numRounds; i++)
            {
                Console.Write("Enter the number of groups for Round " + (i + 1) + ": ");
                int numGroups = Convert.ToInt16(Console.ReadLine());

                comp.rounds[i].AddGroups(numGroups);
            }

            for (int i = 0; i < numRounds; i++)
            {
                Console.Write("Enter the number of races: ");
                int numRaces = Convert.ToInt16(Console.ReadLine());

                List<IRace> races = new List<IRace>();

                for (int j = 0; j < numRaces; j++)
                {
                    Console.WriteLine("1. Singleplayer Race");
                    Console.WriteLine("2. Multiplayer Race");
                    Console.WriteLine("3. Competition Race");
                    Console.WriteLine();
                    Console.Write("Enter the Race Type: ");
                    int raceType = Convert.ToInt16(Console.ReadLine());

                    if (raceType == 1)
                    {


                        string mapLoc = "";

                        Console.Write("Is the map zipped / compressed? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.Write("Enter the link to the file: ");
                            mapLoc = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Enter the link to the folder: ");
                            mapLoc = Console.ReadLine();

                            //Zip folder?
                        }



                        Console.Write("Enter the Race Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter the Weather: ");
                        string weather = Console.ReadLine();

                        bool nightMode;
                        Console.Write("Is the Race at night? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y") { nightMode = true; } else { nightMode = false; }

                        SpRace race = new SpRace(name, weather, nightMode, mapLoc);

                        races.Add(race);
                    }
                    else if (raceType == 2)
                    {
                        string mapLoc = "";

                        Console.Write("Is the map zipped / compressed? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.Write("Enter the link to the file: ");
                            mapLoc = Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Enter the link to the folder: ");
                            mapLoc = Console.ReadLine();

                            //Zip folder?
                        }

                        Console.Write("Enter the IP Address of the Race Host: ");
                        string ipAddress = Console.ReadLine();

                        Console.Write("Enter the Race Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter the Weather: ");
                        string weather = Console.ReadLine();

                        bool nightMode;
                        Console.Write("Is the Race at night? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y") { nightMode = true; } else { nightMode = false; }

                        Console.Write("Enter the Start Interval: ");
                        string startInterval = Console.ReadLine();

                        MpRace race = new MpRace(ipAddress, name, startInterval, weather, nightMode, mapLoc);

                        races.Add(race);
                    }
                    else if (raceType == 3)
                    {
                        string compID = "";

                        Console.Write("Do you know the Competition ID? (y/n): ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.Write("Enter the Competition ID: ");
                            compID = Console.ReadLine();
                        }
                        else
                        {
                            //Select from list
                        }

                        CpRace race = new CpRace(compID);

                        races.Add(race);
                    }

                    comp.rounds[i].AddRaces(races, true);
                    comp.rounds[i].UpdateGroupRaces();
                }
            }
        }
    }
}