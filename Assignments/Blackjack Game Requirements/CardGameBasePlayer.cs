using System.Collections.Generic;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public abstract class CardGameBasePlayer
	{
		public CardGameBasePlayer() 
		{
			Hand = new List<Card>();
		}

        public string Name { get; set; }
        public List<Card> Hand { get; set; }
	}
}
