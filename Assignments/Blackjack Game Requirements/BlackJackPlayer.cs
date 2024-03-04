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
			CardValues = new List<int>();
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

		public void AssignCardValues()
		{
			CardValues.Clear();
			List<int> aces = new List<int>();

			for (int i = 0; i < Hand.Count; i++)
			{
				if (Hand[i].Face == CardFace.Ace) aces.Add(i);
				CardValues.Add(Hand[i].GetValue());
			}

			while (aces.Count > 0 && CardValues.Sum() <= 11)
			{
				CardValues[aces[0]] += 10;
				aces.RemoveAt(0);
			}
		}

		public BlackJackPlayerState PlayerState { get; set; }
		public List<int> CardValues { get; set; }
		public int FinalScore { get; set; }
		public int Bank { get; set; }
		public int CurrentBet { get; set; }
	}
}
