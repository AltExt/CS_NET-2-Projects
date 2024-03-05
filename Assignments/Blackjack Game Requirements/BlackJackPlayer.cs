using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{

	public enum BlackJackPlayerState
	{
		Playing = 0,
		BlackJack,
		PlayerWin,
		PlayerBust,
		Waiting,
	}

	public class BlackJackPlayer: CardGameBasePlayer
	{
		public BlackJackPlayer(): this("", 0) { }

		public BlackJackPlayer(string name, int bank)
		{
			Name = name;
			Bank = bank;
			Hand = new List<Card>();
		}

		public bool MakeBet(int amount)
		{
			if (amount > Bank) return false;
			else
			{
				Bank -= amount;
				CurrentBet += amount;
				return true;
			}
		}

		public void LoseBet()
		{
			Console.WriteLine(Name + " lost " + CurrentBet.ToString());
			PlayerState = BlackJackPlayerState.Waiting;
			CurrentBet = 0;
		}

		public void WinBet(float multiplier)
		{
			PlayerState = BlackJackPlayerState.Waiting;
			int winnings = Convert.ToInt16(CurrentBet * multiplier);
			Console.WriteLine(Name + " winnings: " + winnings);
			CurrentBet = 0;
			Bank += winnings;
		}

		public BlackJackPlayerState PlayerState { get; set; }
		public int Bank { get; set; }
		public int CurrentBet { get; set; }
	}
}
