using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public class BlackjackGame: Game
	{
		public BlackjackGame()
		{
			MyUtils.ConsoleFunctions.SetInitialConsoleColors();
			CurrentPlayer = 0;
			TabString = "  |  ";
			ColWidth = new Card(CardSuit.Diamonds, CardFace.Queen).ToString().Length + 6;
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
				ResetGame();

				// place the bets
				foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>()) PlayerPlaceBet(p);

				// deal two cards to each player and the dealer, this includes a check for round 1 BlackJacks
				DealHands();

				// prompt user to hit / stand
				// user can do this as many times as they like
				for (CurrentPlayer = 0; CurrentPlayer < Players.Count; CurrentPlayer++)
				{
					// draw first here to clear the previous player's turn if any
					DrawHands();
					// then take the turn
					BlackJackPlayer p = (BlackJackPlayer)Players[CurrentPlayer];
					PlayerTakeTurn(p);
					p.PlayerState = CheckPlayerHand(p);

				}

				// Dealer turn
				DealerTakeTurn();

				// Wrap-up
				CheckForWinnersAndPayouts();

				// Prompt to play again
				AskUsersToPlayAgain(ref running);
			}
		}

		private void CheckForWinnersAndPayouts()
		{
			// ensures most up to date values are used
			CheckPlayerHand(TheDealer);
			bool dealerBust = TheDealer.PlayerState == BlackJackPlayerState.PlayerBust;
			int dealerValue = TheDealer.CardValues.Sum();

			string line = new string(' ', ColWidth) + TabString;

			for (int i = 0; i < Players.Count; i++)
			{
				BlackJackPlayer p = (BlackJackPlayer)Players[i];
				CheckPlayerHand(p);

				int betAmt = p.CurrentBet;
				int standardBetReturn = betAmt * 2;
				int blackJackBetReturn = Convert.ToInt32(betAmt * 2.5);
				p.CurrentBet = 0;
				bool addTab = (i != Players.Count - 1);

				if (p.PlayerState == BlackJackPlayerState.BlackJack)
				{
					p.Bank += blackJackBetReturn; // returns original bet + 1.5x original bet
					line += FormatCardNameForDisplay(blackJackBetReturn.ToString(), addTab);
					continue;
				}

				if (p.PlayerState == BlackJackPlayerState.PlayerBust)
				{
					// player lost
					line += FormatCardNameForDisplay((0 - betAmt).ToString(), addTab);
					continue;
				}

				if (dealerBust)
				{
					// any remaining player automatically wins
					p.Bank += betAmt * 2; // returns original bet + 1.0x original bet
					line += FormatCardNameForDisplay(standardBetReturn.ToString(), addTab);
				}
				else
				{
					int playerValue = p.CardValues.Sum();
					if (playerValue == dealerValue)
					{
						p.Bank += betAmt;
						line += FormatCardNameForDisplay(betAmt.ToString(), addTab);	
					}
					else if (playerValue > dealerValue)
					{
						p.Bank += betAmt * 2;
						line += FormatCardNameForDisplay(standardBetReturn.ToString(), addTab);
					}
				}
			}
			DrawHands();
			Console.WriteLine(line);
			Console.ReadLine();
		}

		private void AskUsersToPlayAgain(ref bool running)
		{

		}

		private void DealerTakeTurn()
		{
			// dealer reveals hole card
			TheDealer.HoleCardHidden = false;
			DrawHands();

			Random r = new Random();
			
			// then, while the dealer's card's value less than 17, the dealer must hit
			while (true)
			{
				Console.WriteLine(TheDealer.Name + " is thinking...");
				Thread.Sleep(r.Next(1000, 1500));
				//MyUtils.ConsoleFunctions.ClearCurrentLine();
				int cardValues = TheDealer.CardValues.Sum();

				if (cardValues >= DealerTargetValue)
				{
					Console.WriteLine(TheDealer.Name + " has decided to stand!");
					return;
				}
				else
				{
					Console.Write(TheDealer.Name + " has decided to hit!");
					PlayerActionHit(TheDealer);
					DrawHands();
					TheDealer.PlayerState = CheckPlayerHand(TheDealer);
				}

				if (TheDealer.CardValues.Sum() > TargetValue)
				{
					Console.WriteLine(TheDealer.Name + " has gone bust!");
					return;
				}
			}
		}

		private void ResetGame()
		{
			TheDealer.Hand.Clear();
			TheDealer.DealerDeck.ReturnAllCards();
			TheDealer.DealerDeck.Shuffle();

			CurrentPlayer = 0;
			foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>())  p.Hand.Clear();
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
				if (name == "_eoghan")
				{
					Players.Add(new BlackJackPlayer("eoghan01", 5000));
					Players.Add(new BlackJackPlayer("eoghan02", 5000));
					Players.Add(new BlackJackPlayer("eoghan03", 5000));
					Console.Clear();
					return;
				}
				int bank = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(MIN_AMT, MAX_AMT, "Welcome, " + name + ". Please enter how much money you've brought with you:", "Please enter a value between " + MIN_AMT.ToString() + " and " + MAX_AMT.ToString());
				Players.Add(new BlackJackPlayer(name, bank));
				addNewPlayer = MyUtils.ConsoleFunctions.GetBoolFromUser("Would you like to add another player? (y/n)");
			}
			Console.Clear();
		}

		private void SetupDealer()
		{
			TheDealer = new Dealer("Dealer");
		}

		private void PlayerPlaceBet(BlackJackPlayer player)
		{
			const int MIN_BET = 5;
			string promptMessage = player.Name + ", what would you like to bet on this game?\nMinimum buy in is currently: " + MIN_BET.ToString() + ", and you have " + player.Bank.ToString() + " remaining in your bank.";
			string errorMessage = "Please enter a number between " + MIN_BET.ToString() + " and " + player.Bank.ToString();
			int amt = 0;

			while (true)
			{
				amt = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(MIN_BET, player.Bank, promptMessage, errorMessage);
				Console.WriteLine(player.Name + ", you wish to bet " + amt + ". Is this amount correct? (y/n)");
				if (MyUtils.ConsoleFunctions.GetBoolFromUser()) break;
				Console.WriteLine("In that case, please enter another amount.");
			}
			player.MakeBet(amt);
		}

		private void PlayerTakeTurn(BlackJackPlayer player)
		{
			if (player.PlayerState == BlackJackPlayerState.Playing)
			{

				// turn is ended when the player stands, or their card value goes beyond 21
				int currentCardValueTotal = player.CardValues.Sum();
				int currentSelection = 0;
				bool clearLine = false;
				List<string> options = new List<string> { "Hit", "Stand", "Quit" };

				while (currentCardValueTotal < TargetValue)
				{

					// display option list to player
					if (clearLine) MyUtils.ConsoleFunctions.ClearCurrentLine();
					clearLine = true;
					for (int i = 0; i < options.Count; i++)
					{
						if (i == currentSelection)
						{
							Console.BackgroundColor = ConsoleColor.Green;
							Console.ForegroundColor = ConsoleColor.Black;
						}
						Console.Write(options[i] + "\t");
						MyUtils.ConsoleFunctions.ResetConsoleColors();
					}


					// get player input
					ConsoleKey pressedKey = MyUtils.ConsoleFunctions.GetConsoleKeyFromUser();
					bool enterPressed = false;
					
					// handle player input
					switch (pressedKey)
					{
						case ConsoleKey.LeftArrow:
							currentSelection--;
							if (currentSelection < 0) currentSelection += options.Count;
							break;
						case ConsoleKey.RightArrow:
							currentSelection++;
							if (currentSelection >= options.Count) currentSelection = 0;
							break;
						case ConsoleKey.Enter:
							enterPressed = true;
							break;
					}

					if (enterPressed)
					{
						switch (currentSelection)
						{
							case 0: //hit
								PlayerActionHit(player);
								clearLine = false;
								break;
							case 1: // stand
								return;
						}
						currentCardValueTotal = player.CardValues.Sum();
					}
				}
			}
		}

		private void DealHands()
		{
			for (int i = 0; i < 2; i++)
			{
				// give each player a card
				foreach (BlackJackPlayer player in Players.Cast<BlackJackPlayer>())
				{
					player.Hand.Add(TheDealer.DealerDeck.GetNextCard());
				}

				// then the dealer
				TheDealer.Hand.Add(TheDealer.DealerDeck.GetNextCard());
			}

			foreach (BlackJackPlayer player in Players.Cast<BlackJackPlayer>())
			{
				CheckPlayerHand(player);
			}

			CheckPlayerHand(TheDealer);
		}

		private void DrawHands()
		{
			Console.Clear();

			// define some variables here
			int totalWidth = 0;
			int maxCards = 0;

			// draw first line, playernames etc
			// starting at -1 for the dealer
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
					switch (TheDealer.PlayerState)
					{
						case BlackJackPlayerState.Playing: name += "[P]"; break;
						case BlackJackPlayerState.BlackJack: name += "[BJ]"; break;
						case BlackJackPlayerState.PlayerWin: name += "[W]"; break;
						case BlackJackPlayerState.PlayerBust: name += "[B]"; break;
					}
				}
				else // this adds the player[i]'s name
				{
					if (Players[i].Hand.Count > maxCards) maxCards = Players[i].Hand.Count;
					name += Players[i].Name;
					BlackJackPlayer p = (BlackJackPlayer)Players[i];
					switch (p.PlayerState)
					{
						case BlackJackPlayerState.Playing: name += "[P]"; break;
						case BlackJackPlayerState.BlackJack: name += "[BJ]"; break;
						case BlackJackPlayerState.PlayerWin: name += "[W]"; break;
						case BlackJackPlayerState.PlayerBust: name += "[B]"; break;
					}
				}
				// write the name and reset the console colors
				Console.Write(name);
				MyUtils.ConsoleFunctions.ResetConsoleColors();

				// have to add padding seperately here so it is not highlighted
				string padding = new string(' ', ColWidth - name.Length);
				Console.Write(padding);

				// also track the total width for the buffer, a line of "========="
				totalWidth += ColWidth;

				// only add the tab id this player is not the last player in the list
				if (i != Players.Count - 1)
				{
					Console.Write(TabString);
					totalWidth += TabString.Length;
				}
			}

			if (Console.WindowWidth < totalWidth) Console.WindowWidth = totalWidth + 1;

			// write the buffer below the previous line
			string buffer = new string('=', totalWidth);
			Console.WriteLine("\n" + buffer);

			// then gather cards into one string to draw
			string line = string.Empty;
			for (int i = 0; i < maxCards; i++)
			{
				line = string.Empty;
				// add the dealer's card
				if (i < TheDealer.Hand.Count)
				{
					if (i == 0 && TheDealer.HoleCardHidden)
					{
						// do not reveal the dealer's first card
						line += FormatCardNameForDisplay("*** *** ***");
					}
					else
					{
						// this one line gets the dealers card at i, converts it to a string and adds any needed padding, then adds it to the line string
						line += FormatCardNameForDisplay(TheDealer.Hand[i].ToString() + " " + TheDealer.CardValues[i].ToString());
					}
				}
				else
				{
					// this adds a blank space if the dealer has no more cards in their hand
					line += FormatCardNameForDisplay("");
				}
				
				for (int j = 0; j < Players.Count; j++) 
				{
					BlackJackPlayer player = (BlackJackPlayer)Players[j];
					string s = string.Empty;
					if (i < player.Hand.Count)
					{
						// similar to line above, adds all needed formatting to this player's card
						line += FormatCardNameForDisplay(player.Hand[i].ToString() + " " + player.CardValues[i].ToString(), (j != Players.Count - 1));
					}
					else
					{
						line += FormatCardNameForDisplay("", (j != Players.Count - 1));
					}
				}
				Console.WriteLine(line);
			}
			// buffer again
			Console.WriteLine(buffer);
			line = string.Empty;

			// write the total for each player in the centre of their column
			// starting with dealer, hiding the hole card value if needed
			int dealerCardValues = TheDealer.CardValues.Sum();
			if (TheDealer.HoleCardHidden) { dealerCardValues -= TheDealer.CardValues[0]; }
			line += FormatHandValueForDisplay(dealerCardValues);

			for (int i = 0; i < Players.Count; i++)
			{
				BlackJackPlayer p = (BlackJackPlayer)Players[i];
				int cardValues = p.CardValues.Sum();
				line += FormatHandValueForDisplay(cardValues, (i != Players.Count - 1));

				//line += (i != Players.Count - 1) ? FormatHandValueForDisplay(p.CardValues.Sum(), colWidth) + tabString : FormatHandValueForDisplay(p.CardValues.Sum(), colWidth);
			}

			Console.WriteLine(line);
			Console.WriteLine(buffer);
		}

		private void PlayerActionHit(BlackJackPlayer player)
		{
			player.Hand.Add(TheDealer.DealerDeck.GetNextCard());
			CheckPlayerHand(player);
			DrawHands();
		}

		private BlackJackPlayerState CheckPlayerHand(BlackJackPlayer player)
		{
			player.AssignCardValues();
			int totalScore = player.CardValues.Sum();
			if (totalScore > TargetValue) return BlackJackPlayerState.PlayerBust;
			if (totalScore == TargetValue)
			{
				if (player.Hand.Count == 2) return BlackJackPlayerState.BlackJack;
				else return BlackJackPlayerState.PlayerWin;
			}
			return BlackJackPlayerState.Playing;
		}

		/*
		private BlackJackPlayerState CheckPlayerHand(BlackJackPlayer player)
		{
			int handSize = player.Hand.Count;
			List<int> results = GetAllHandValues(player);

			if (results.Min() > TargetValue) return BlackJackPlayerState.PlayerBust;
			if (results.Max())


				return BlackJackPlayerState.Playing;
		}

		private List<int> GetAllHandValues(BlackJackPlayer player)
		{
			List<int> output = new List<int>();
			int numAces = 0;
			int result = 0;

			for (int i = 0; i < player.Hand.Count; i++)
			{
				if (player.Hand[i].Face == CardFace.Ace) numAces++;
				result += player.Hand[i].GetValue();
			}
			output.Add(result);

			while (numAces > 0 && result <= 11)
			{
				result += 10;
				output.Add(result);
			}

			return output;
		}
		*/

		private string FormatCardNameForDisplay(string s, bool addTab = true)
		{
			string output = s;

			output += new string(' ', ColWidth - s.Length);
			if (addTab) output += TabString;

			return output;
		}

		private string FormatHandValueForDisplay(int cardValue, bool addTab = true)
		{
			string output = "  ";
			if (cardValue > TargetValue)
			{
				output += "Bust!";
			}
			else if (cardValue == TargetValue)
			{
				output += "Winner!";
			}
			else
			{
				output += "Total Score: " + cardValue.ToString();
			}

			int remainder = ColWidth - output.Length;
			output += new string(' ', remainder);
			if (addTab) output += TabString;

			return output;
		}
















		static readonly int TargetValue = 21;
		static readonly int DealerTargetValue = 17;
		public int CurrentPlayer { get; set; }
		private int ColWidth { get; set; }
		private string TabString { get; set; }
		//public List<BlackJackPlayer> Players { get; set; }
		//public Dealer TheDealer { get; set; }
	}
}