using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_NET_2_Projects
{
	public class Program
	{
		static void Main()
		{
			MyUtils.ConsoleFunctions.SetInitialConsoleColors();

			AssignmentViewer viewer = new AssignmentViewer();
			viewer.Run();

			Deck Cards = new Deck();
			while (Cards.RemainingCards() > 0)
			{
				Console.WriteLine(Cards.GetNextCard().ToString());
			}
			MyUtils.ConsoleFunctions.WaitForEnter();

			Cards.ReturnAllCards();
			Cards.Shuffle();

			while (Cards.RemainingCards() > 0)
			{
				Console.WriteLine(Cards.GetNextCard().ToString());
			}
			MyUtils.ConsoleFunctions.WaitForEnter();
		}
	}
}
