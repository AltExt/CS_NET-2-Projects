using System;

namespace CS_NET_2_Projects
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
		public Card()
		{
			Suit = CardSuit.Spades;
			Face = CardFace.Ace;
		}

		public Card(CardSuit suit, CardFace face)
		{
			Suit = suit;
			Face = face;
		}

		public override string ToString()
		{
			string output = string.Empty;
			output += faceValues[Convert.ToInt32(Face)-1] + " of ";

			switch (Suit)
			{
				case CardSuit.Spades:
					output += "Spades";
					break;
				case CardSuit.Hearts:
					output += "Hearts";
					break;
				case CardSuit.Clubs:
					output += "Clubs";
					break;
				case CardSuit.Diamonds:
					output += "Diamonds";
					break;
			}

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

		private CardSuit Suit { get; set; }
		private CardFace Face { get; set; }

		private static readonly string[] faceValues = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
	}
}
