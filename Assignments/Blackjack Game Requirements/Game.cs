using System;
using System.Collections.Generic;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public abstract class Game
	{
		public abstract void Play();

		public void ListPlayers()
		{
			Console.WriteLine(Name);
			Console.WriteLine("Dealer: " + TheDealer.Name);
			Console.WriteLine("Players: ");
			foreach(BlackJackPlayer p in Players) Console.WriteLine("\t" + p.Name);
		}

		public string Name { get; set; }

		public List<CardGameBasePlayer> Players { get; set; }
		public Dealer TheDealer { get; set; }

	}
}
