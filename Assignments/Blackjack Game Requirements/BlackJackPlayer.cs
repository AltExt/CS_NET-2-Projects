using System.Collections.Generic;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
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
                return true;
            }
        }

        public int Bank { get; set; }
    }
}
