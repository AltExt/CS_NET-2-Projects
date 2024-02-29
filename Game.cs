using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects
{
	public class Game
	{
        public List<string> Players { get; set; }
        public string Name { get; set; }
        public string Dealer { get; set; }

        public void ListPlayers()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Dealer: " + Dealer);
            Console.WriteLine("Players: ");
            foreach(string player in Players) Console.WriteLine("\t" + player);
        }
    }
}
