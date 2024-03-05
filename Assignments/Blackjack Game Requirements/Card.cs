using System;

namespace CS_NET_2_Projects.Assignments.Blackjack_Game_Requirements
{
	public enum CardSuit
	{
		Spades = 0,
		Hearts,
		Clubs,
		Diamonds
	}

	public enum CardFace
	{
		Ace = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Ten = 10,
		Jack = 11,
		Queen = 12,
		King = 13
	}

	public class Card
	{
		public Card(): this(CardSuit.Spades, CardFace.Ace) { }

		public Card(CardSuit suit, CardFace face)
		{
			Suit = suit;
			Face = face;
			Value = 0;
		}

		public override string ToString()
		{
			string output = string.Empty;

			output += Enum.GetName(typeof(CardFace), Face);
			output += " of ";
			output += Enum.GetName(typeof(CardSuit), Suit);

			return output;
		}

		public int GetValue(bool highAce = false)
		{
			/**/
			if (Face == CardFace.Ace) return GetAceValue(highAce);
			else if (Face >= CardFace.Jack) return 10;
			else return Convert.ToInt32(Face);
		}

		private int GetAceValue(bool highAce = false)
		{
			if (highAce) return 11;
			else return 1;
		}

		public CardSuit Suit { get; set; }
		public CardFace Face { get; set; }
        public int Value { get; set; }
    }
}
