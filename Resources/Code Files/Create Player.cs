using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatePlayer();
        }

        static void CreatePlayer()
        {
            Player player = new Player();

            //name, club, email, username

         
            Console.Write("Enter the Player Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the Player Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter the Club: ");
            string club = Console.ReadLine();

            Console.Write("Enter the Catching Features Username: ");
            string username = Console.ReadLine();

            player.Name = name;
            player.Email = email;
            player.Club = club;
            player.Username = username;
        }
    }
}
