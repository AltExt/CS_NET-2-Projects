using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public class BlackJackGame: Game
	{
		// properties
		private int Round { get; set; }
		private int MinBuyIn { get; set; }
		private int TargetValue { get; set; }
		private int DealerCutOff { get; set; }
		private int CurrentPlayer { get; set; }

		// Draw properties
		private int ColWidth { get; set; }
		private int HandColHeight { get; set; }
		private bool GridDrawn { get; set; }


		public BlackJackGame()
		{
			Round = 1;
			MinBuyIn = 5;
			CurrentPlayer = 0;
			TargetValue = 21;
			DealerCutOff = 17;
			GridDrawn = false;
			ColWidth = new Card(CardSuit.Diamonds, CardFace.Queen).ToString().Length + 10; // wide enough for everything
			Players = new List<CardGameBasePlayer>();
		}

		public override void Play()
		{
			// setup players and dealer
			SetupGame();

			// while loop
			bool running = true;
			while (running)
			{
				// place bets
				PlaceBets();

				// deal cards
				DealCards();

				// draw hand
				DrawHand();

				// hit / stand
				PlayerTurns();
				DealerTurn();

				// check final hands
				// payout
				EndGame();

				// ask to play again
				PlayAgain(ref running);
			}
		}

		private void SetupGame()
		{
			// init dealer and get all players
			TheDealer = new Dealer("Dealer");
			TheDealer.DealerDeck.Shuffle();

			while (true)
			{
				string name = MyUtils.ConsoleFunctions.GetTextFromUser("Please enter your name: ");
				if (name[0] == '_')
				{
					for (int i = 0; i < Convert.ToInt32(name[1].ToString()); i++)
					{
						Players.Add(new BlackJackPlayer("_" + i.ToString(), 50000));
					}
					return;
				}
				int bank = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 1000000, "Please tell us how much money you have brought", "Please enter a number between 0 and 1000000.");
				Players.Add(new BlackJackPlayer(name, bank));
				if (!MyUtils.ConsoleFunctions.GetBoolFromUser("Would you like to add another player? (y/n)")) break;
			}
		}

		private void ResetGame()
		{
			ClearConsole();

			TheDealer.DealerDeck.ReturnAllCards();
			TheDealer.DealerDeck.Shuffle();
			TheDealer.Hand.Clear();
			TheDealer.HoleCardHidden = true;

			foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>())
			{
				p.Hand.Clear();
				p.CurrentBet = 0;
				p.PlayerState = BlackJackPlayerState.Playing;
			}
		}

		private void PlaceBets()
		{
			// min buy in increases each round
			int minBuyIn = MinBuyIn * Round;

			// get each player's bet
			foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>())
			{
				int betAmt = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(minBuyIn, p.Bank,
					p.Name + ", please enter the amount you wish to bet on this round.\nMinimum buy in is currently: " + minBuyIn.ToString(),
					"Please enter a number between " + minBuyIn.ToString() + " and " + p.Bank.ToString());
				p.MakeBet(betAmt);
			}
		}

		// wait bool is used to deal the cards one by one, if false all cards are dealt and drawn once
		private void DealCards(bool wait = true)
		{
			// deal two cards to each player and the dealer
			if (wait)
			{
				for (int i = 0; i < 2; i++)
				{
					HandColHeight = i + 1;
					DrawHandGrid(false);
					foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>())
					{
						p.Hand.Add(TheDealer.DealerDeck.GetNextCard());
						DrawHand();
						Thread.Sleep(250);
					}
					TheDealer.Hand.Add(TheDealer.DealerDeck.GetNextCard());
					DrawHand();
					Thread.Sleep(250);
				}
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>())
					{
						p.Hand.Add(TheDealer.DealerDeck.GetNextCard());
					}
					TheDealer.Hand.Add(TheDealer.DealerDeck.GetNextCard());
				}
			}
			CheckAllPlayerHands();
			CheckSinglePlayerHand(TheDealer);
		}

		private void CheckAllPlayerHands()
		{
			foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>())
			{
				CheckSinglePlayerHand(p);
			}
		}

		private void CheckSinglePlayerHand(BlackJackPlayer p)
		{
			int aceAdditionalValue = 10;

			// loop over all cards using ace = 1 first
			// track the number and position of aces seen
			List<int> aces = new List<int>();
			for (int i = 0; i < p.Hand.Count; i++)
			{
				p.Hand[i].Value = GetCardValue(p.Hand[i]);
				if (p.Hand[i].Face == CardFace.Ace) aces.Add(i);
			}
			int totalValue = p.Hand.Sum(x => x.Value);

			// if the total value is 11 or less then see if there are any aces, and add 10 to the score and to that ace, until score is greater than 11
			while (totalValue <= (TargetValue - aceAdditionalValue) && aces.Count != 0)
			{
				p.Hand[aces[0]].Value += aceAdditionalValue;
				aces.RemoveAt(0);
				totalValue += aceAdditionalValue;
			}

			UpdatePlayerState(p);
		}

		private void UpdatePlayerState(BlackJackPlayer p)
		{
			// this funciton determines the state of the player's hand based on their score
			int totalValue = p.Hand.Sum(x => x.Value);
			if (totalValue == TargetValue)
			{
				if (p.Hand.Count == 2) p.PlayerState = BlackJackPlayerState.BlackJack;
				else p.PlayerState = BlackJackPlayerState.PlayerWin;
			}
			else if (totalValue > TargetValue) p.PlayerState = BlackJackPlayerState.PlayerBust;
			else p.PlayerState = BlackJackPlayerState.Playing;
		}

		private int GetCardValue(Card c)
		{
			// gets the value of a given card
			if (c.Face == CardFace.Ace) return 1;
			else if (c.Face >= CardFace.Jack) return 10;
			else return Convert.ToInt32(c.Face);
		}

		private void PlayerTurns()
		{
			for (CurrentPlayer = 0; CurrentPlayer < Players.Count; CurrentPlayer++)
			{
				BlackJackPlayer p = (BlackJackPlayer)Players[CurrentPlayer];
				PlayerTakeTurn(p);
			}
		}

		private void PlayerTakeTurn(BlackJackPlayer p)
		{
			List<string> options = new List<string> { "Hit", "Stand" };
			int selection = 0;

			while (p.PlayerState == BlackJackPlayerState.Playing)
			{
				// draw current hands to screen
				ClearConsole();
				DrawHand();

				// draw options for current player
				Console.Write("Current player: ");
				Console.BackgroundColor = ConsoleColor.Green;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(p.Name);
				MyUtils.ConsoleFunctions.ResetConsoleColors();
				Console.Write("\n");

				for (int i = 0; i < options.Count; i++)
				{
					if (i == selection)
					{
						Console.BackgroundColor = ConsoleColor.Green;
						Console.ForegroundColor = ConsoleColor.Black;
					}
					Console.Write(options[i]);
					if (i + 1 != options.Count) Console.Write("  ");
					MyUtils.ConsoleFunctions.ResetConsoleColors();
				}

				// get player input
				ConsoleKey pressedKey = MyUtils.ConsoleFunctions.GetConsoleKeyFromUser();
				bool enterPressed = false;

				MyUtils.ConsoleFunctions.ClearLineAt(Console.CursorTop);
				MyUtils.ConsoleFunctions.ClearLineAt(Console.CursorTop - 1);

				// handle player input
				switch (pressedKey)
				{
					case ConsoleKey.LeftArrow:
						selection--;
						if (selection < 0) selection += options.Count;
						break;
					case ConsoleKey.RightArrow:
						selection++;
						if (selection >= options.Count) selection = 0;
						break;
					case ConsoleKey.Enter:
						enterPressed = true;
						break;
				}

				if (enterPressed)
				{
					if (selection == 0) HitPlayer(p);

					if (selection == 1) break;
				}
			}
		}

		// wait bool here is to simulate the dealer thinking about their choce
		private void DealerTurn(bool wait = true)
		{
			// the dealer will hit until their hand has a value of 17 or greater
			// also now reveal the dealer's hole card
			TheDealer.HoleCardHidden = false;
			while (TheDealer.Hand.Sum(x => x.Value) < TargetValue)
			{
				ClearConsole();
				DrawHand();
				Console.Write("Dealer is thinking");
				if (wait)
				{
					for (int i = 0; i < 3; i++)
					{
						Thread.Sleep(250);
						Console.Write('.');
					}
					Thread.Sleep(1000);
				}
				MyUtils.ConsoleFunctions.ClearCurrentLine();
				if (TheDealer.Hand.Sum(x => x.Value) >= DealerCutOff ) // the dealer's hand value is greater than or equal to 17
				{
					Console.Write("Dealer decides to stand!");
					if (wait) Thread.Sleep(1000);
					MyUtils.ConsoleFunctions.ClearCurrentLine();
					return;
				}
				else
				{
					Console.Write("Dealer decides to hit!");
					HitPlayer(TheDealer);
					if (wait) Thread.Sleep(1000);
					MyUtils.ConsoleFunctions.ClearCurrentLine();
				}
			}
		}

		private void HitPlayer(BlackJackPlayer p)
		{
			p.Hand.Add(TheDealer.DealerDeck.GetNextCard());
			CheckSinglePlayerHand(p);
		}

		private void EndGame()
		{
			// check all hands one more time to get their final state
			CheckAllPlayerHands();
			CheckSinglePlayerHand(TheDealer);
			int dealerScore = TheDealer.Hand.Sum(x => x.Value);
			bool dealerBust = dealerScore > TargetValue;
			DrawHand();
			// loop over each player, checking first if they are bust or scored a blackjack
			// then compare their score to dealer, player wins if the dealer is bust and they are not, or if player's score is higher than dealers
			foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>())
			{
				/* */if (p.PlayerState == BlackJackPlayerState.PlayerBust) p.LoseBet();
				else if (p.PlayerState == BlackJackPlayerState.BlackJack)
				{
					p.WinBet(2.5f);
				}
				else
				{
					if (dealerBust && p.PlayerState != BlackJackPlayerState.PlayerBust)
					{
						p.WinBet(2.0f);
					}
					else
					{
						// dealer not bust and player not bust
						if (dealerScore < p.Hand.Sum(x => x.Value))
						{
							p.WinBet(2.0f);
						}
						else
						{
							p.LoseBet();
						}
					}
				}

			}
		}

		private void PlayAgain(ref bool running)
		{
			// prompt user to play again, and if yes checks that each player has enough in bank to pay the minimum buy in
			bool playAgain = MyUtils.ConsoleFunctions.GetBoolFromUser("Play again? (y/n)");
			if (playAgain)
			{
				Round++;
				for (int i = 0; i < Players.Count; i++)
				{
					BlackJackPlayer p = (BlackJackPlayer)Players[i];
					if (p.Bank < MinBuyIn * Round)
					{
						Console.WriteLine(p.Name + " does not have enough money in the bank for the next round.");
						if (MyUtils.ConsoleFunctions.GetBoolFromUser("Would you like to add funds to continue playing? (y/n)"))
						{
							int amt = MyUtils.ConsoleFunctions.GetIntFromUserWithBounds(0, 100000);
							p.Bank += amt;
						}
						else
						{
							Console.WriteLine("Removing player: " + p.Name);
							Players.RemoveAt(i);
							i--;
						}
					}
				}
				ResetGame();
			}
			else
			{
				running = false;
			}
		}

		//===========


		/*
				// #=====#=====#=====#
				// |     |     |     | names
				// |     |     |     | current bets
				// #=====#=====#=====#
				// |     |     |     | cards + value
				// |     |     |     |
				// |     |     |     |
				// |     |     |     |
				// #=====#=====#=====#
				// |     |     |     | total value
				// |     |     |     | status
				// #=====#=====#=====#
		*/
		// next two functions draw the dealer and player hands to the console in above format
		// by moving the cursor around it it possible to draw the grid first and then add the text after
		private void DrawHand()
		{
			if (!GridDrawn) DrawHandGrid();
			int drawRelativePos = 2;
			int initialCursorX = Console.CursorLeft;
			int initialCursorY = Console.CursorTop;

			// create a temp list of all players includeing the dealer
			List<BlackJackPlayer> AllPlayersIncDealer = new List<BlackJackPlayer> { TheDealer };
			foreach (BlackJackPlayer p in Players.Cast<BlackJackPlayer>()) AllPlayersIncDealer.Add(p);

			// loop over each element in that list
			for (int i = 0; i < AllPlayersIncDealer.Count; i++)
			{
				BlackJackPlayer p = AllPlayersIncDealer[i];
				int thisDrawX = drawRelativePos + (ColWidth * i);
				int thisDrawY = 1;
				// #=====#=====#=====#
				// adds a highlight to the current player, +1 because of dealer offset
				if (i == CurrentPlayer + 1) MyUtils.ConsoleFunctions.SwapConsoleColors();
				WriteStringAtPosition(p.Name, thisDrawX, thisDrawY);
				MyUtils.ConsoleFunctions.ResetConsoleColors();

				thisDrawY++;
				if (i == 0)
				{
					// draw the round number under the dealer's name
					WriteStringAtPosition("Round: " + Round.ToString(), thisDrawX, thisDrawX);
				}
				else
				{ 
					// only need to draw this line for non dealer players
					WriteStringAtPosition(p.CurrentBet.ToString(), thisDrawX, thisDrawY);
				}
				thisDrawY += 2; // need to add 2 to skip over the grid line
				// #=====#=====#=====#
				for (int j = 0; j < p.Hand.Count; j++)
				{
					// if the dealer's hole card is still hidden draw ***
					if (i == 0 && j == 0 && TheDealer.HoleCardHidden) // i == 0 is dealer, j == - is first card, 
					{
						WriteStringAtPosition("*** ** ***", thisDrawX, thisDrawY);
					}
					else
					{
						WriteStringAtPosition(p.Hand[j].ToString() + " " + p.Hand[j].Value.ToString(), thisDrawX, thisDrawY);
					}
					thisDrawY++;
				}
				thisDrawY = 5 + HandColHeight; // HandColHeight is equal to the largest hand size among all players, adding 5 here to skip 3 grid lines and name / betAmt lines
				// #=====#=====#=====#
				int handValue = p.Hand.Sum(x => x.Value);
				if (i == 0 && TheDealer.HoleCardHidden)
				{
					// don't show the value of the hole card!
					if (TheDealer.Hand.Count > 0) handValue -= TheDealer.Hand[0].Value; 
				}
				WriteStringAtPosition(handValue.ToString(), thisDrawX, thisDrawY);
				thisDrawY++;
				// displays the player state (plaing, bust, blackjack or win)
				string s = Enum.GetName(typeof(BlackJackPlayerState), p.PlayerState);
				WriteStringAtPosition(s, thisDrawX, thisDrawY);
			}

			// set the cursor back to it's initial position
			Console.CursorLeft = initialCursorX;
			Console.CursorTop = initialCursorY;
		}

		private void DrawHandGrid(bool checkHandCol = true)
		{
			// create the strings needed to draw the grid
			string s = "#" + new string('=', ColWidth - 1);
			string rowLineString = MyUtils.StringFunctions.RepeatString(s, Players.Count + 1) + "#";
			s = "|" + new string(' ', ColWidth - 1);
			string rowEmptyString = MyUtils.StringFunctions.RepeatString(s, Players.Count + 1) + "|";
			if (Console.WindowWidth < rowEmptyString.Length) Console.WindowWidth = rowEmptyString.Length + 1;

			if (checkHandCol) HandColHeight = Players.Max(x => x.Hand.Count);

			ClearConsole();
			// top row
			Console.WriteLine(rowLineString);
			Console.WriteLine(rowEmptyString);
			Console.WriteLine(rowEmptyString);
			// card area
			Console.WriteLine(rowLineString);
			for (int i = 0; i < HandColHeight; i++) Console.WriteLine(rowEmptyString);
			Console.WriteLine(rowLineString);
			// bottom row
			Console.WriteLine(rowEmptyString);
			Console.WriteLine(rowEmptyString);
			Console.WriteLine(rowLineString);

			GridDrawn = true;
		}

		// wrapper function to type less
		private void WriteStringAtPosition(string s, int x, int y)
		{
			MyUtils.ConsoleFunctions.WriteStringAtPosition(s, x, y);
		}

		// wrapper function that ensures the grid is drawn after a console.clear
		private void ClearConsole()
		{
			Console.Clear();
			GridDrawn = false;
		}
	}
}
