using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public class Dealer: CardGameBasePlayer
	{
		public Dealer():base() { }

        public Deck DealerDeck { get; set; }
    }

}
