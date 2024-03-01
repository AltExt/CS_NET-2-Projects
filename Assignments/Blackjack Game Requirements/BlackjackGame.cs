using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public enum BlackJackKeyAction
	{
		NoAction = 0,
	}

	public class BlackjackGame: Game
	{
		public BlackjackGame()
		{
			MyUtils.ConsoleFunctions.SetInitialConsoleColors();
			CurrentPlayer = 0;
		}

		public override void Play()
		{
			// get the players
			SetupPlayers();

			// setup dealer
			SetupDealer();


			bool running = true;
			while (running)
			{
				ThePot = 0;

				// place the bets
				foreach (BlackJackPlayer player in Players.Cast<BlackJackPlayer>()) PlayerPlaceBet(player);

				// deal two cards to each player and the dealer
				DealHands();

				// draw current hand to screen
				DrawHands(true);

				// prompt user to hit / stand
				// user can do this as many times as they like

				// on hit give the user the next card and add the value 
			}
		}

		private void SetupPlayers()
		{
			Players = new List<CardGameBasePlayer>();
			bool addNewPlayer = true;
			const int MIN_AMT = 10;
			const int MAX_AMT = 10000;
			while (addNewPlayer)
			{
				string name = MyUtils.ConsoleFunctions.GetTextFromUser("Please enter your name: ");
				int bank = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(MIN_AMT, MAX_AMT, "Welcome, " + name + ". Please enter how much money you've brought with you:", "Please enter a value between " + MIN_AMT.ToString() + " and " + MAX_AMT.ToString());
				Players.Add(new BlackJackPlayer(name, bank));
				addNewPlayer = MyUtils.ConsoleFunctions.GetBoolFromUser("Would you like to add another player? (y/n)");
			}
			Console.Clear();
		}

		private void SetupDealer()
		{
			TheDealer = new Dealer();
			TheDealer.Name = "Dealer";
			TheDealer.DealerDeck = new Deck();
			TheDealer.DealerDeck.Shuffle();

			TheDealer.Hand.Add(TheDealer.DealerDeck.GetNextCard());
		}

		private void PlayerPlaceBet(BlackJackPlayer player)
		{
			const int MIN_BET = 5;
			Console.WriteLine(player.Name + ", what would you like to bet on this game? Minimum buy in is currently: " + MIN_BET.ToString());
			int amt = 0;
			while (true)
			{
				amt = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(MIN_BET, player.Bank);
				Console.WriteLine(player.Name + ", you wish to bet " + amt + ". Is this amount correct? (y/n)");
				if (MyUtils.ConsoleFunctions.GetBoolFromUser()) break;
				Console.WriteLine("In that case, please enter another amount.");
			}
			player.MakeBet(amt);
			ThePot += amt;
		}

		private void DealHands()
		{
			for (int i = 0; i < 2; i++)
			{
				// give each player a card
				foreach (BlackJackPlayer player in Players)
				{
					player.Hand.Add(TheDealer.DealerDeck.GetNextCard());
				}

				// then the dealer
				TheDealer.Hand.Add(TheDealer.DealerDeck.GetNextCard());
			}
		}

		private void DrawHands(bool holeCardHidden)
		{
			Console.Clear();

			// define some variables here
			string tabString = "  |  ";
			int cardValueMaxWidth = 3;
			int additionalPadding = 3;
			int totalWidth = 0;
			int maxCards = 0;
			int colWidth = new Card(CardSuit.Diamonds, CardFace.Queen).ToString().Length + cardValueMaxWidth + additionalPadding;

			// draw first line, playernames etc
			// starting at -1 forthe dealer
			// might not be the best idea...
			for (int i = -1; i < Players.Count; i++)
			{
				// this highlights the current player
				if (i == CurrentPlayer)
				{
					Console.BackgroundColor = ConsoleColor.White;
					Console.ForegroundColor = ConsoleColor.Black;
				}
				string name = "";
				if (i == -1) // this adds the dealers name
				{
					if (TheDealer.Hand.Count > maxCards) maxCards = TheDealer.Hand.Count;
					name += "  " + TheDealer.Name;
				}
                else // this adds the player[i]'s name
				{
					if (Players[i].Hand.Count > maxCards) maxCards = Players[i].Hand.Count;
					name += Players[i].Name;
                }
				// write the name and reset the console colors
				Console.Write(name);
				MyUtils.ConsoleFunctions.ResetConsoleColors();

				// have to add padding seperately here so it is not highlighted
				string padding = new string(' ', colWidth - name.Length);
				Console.Write(padding);

				// also track the total width for the buffer, a line of "========="
				totalWidth += colWidth;

				// only add the tab id this player is not the last player in the list
				if (i != Players.Count - 1)
				{
					Console.Write(tabString);
					totalWidth += tabString.Length;
				}
            }

			if (Console.WindowWidth < totalWidth) Console.WindowWidth = totalWidth + 1;

			// write the buffer below the previous line
			string buffer = new string('=', totalWidth);
			Console.WriteLine("\n" + buffer);

			// then gather cards into one string to draw
			for (int i = 0; i < maxCards; i++)
			{
				string line = string.Empty;
				
				// add the dealer's card
				if (i < TheDealer.Hand.Count)
				{
					if (i == 0 && holeCardHidden)
					{
						// do not reveal the dealer's first card
						line += FormatStringBlackjackDisplay("*** *** ***", colWidth) + tabString;
					}
					else
					{
						// this one line gets the dealers card at i, converts it to a string and adds any needed padding, then adds it to the line string
						line += FormatStringBlackjackDisplay(TheDealer.Hand[i].ToString(), colWidth);
						//line += FormatStringBlackjackDisplay();
					}
				}
				else
				{
					// this adds a blank space if the dealer has no more cards in their hand
					line += FormatStringBlackjackDisplay("", colWidth) + tabString;
				}
				
				for (int j = 0; j < Players.Count; j++) 
				{
					string s = string.Empty;
					if (i < Players[j].Hand.Count)
					{
						// similar to line above, adds all needed formatting to this player's card
						line += FormatStringBlackjackDisplay(Players[j].Hand[i].ToString(), colWidth);
					}
					else
					{
						line += FormatStringBlackjackDisplay("", colWidth);
					}
					if (j != Players.Count - 1) line += tabString;
				}
				Console.WriteLine(line);
			}

			MyUtils.ConsoleFunctions.WaitForEnter();
		}

		private void HitPlayer(BlackJackPlayer player)
		{
			// hard
		}

        public int ThePot { get; set; }
		public int CurrentPlayer { get; set; }
		//public List<BlackJackPlayer> Players { get; set; }
		//public Dealer TheDealer { get; set; }

		private string FormatStringBlackjackDisplay(string s, int width)
		{
			string output = s;

			output += new string(' ', width - s.Length);

			return output;
		}
	}
}