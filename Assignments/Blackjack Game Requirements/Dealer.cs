using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public class Dealer: BlackJackPlayer
	{
		public Dealer():base() { }
		
		public Dealer(string name): base(name, 0)
		{
			HoleCardHidden = true;
			DealerDeck = new Deck();
			DealerDeck.Shuffle();
		}

        public Deck DealerDeck { get; set; }

		public bool HoleCardHidden { get; set; }
    }

}
