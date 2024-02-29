using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CS_NET_2_Projects
{
	internal class Deck
	{
		public Deck() 
		{
			cards = new List<Card>();
			returnedCards = new List<Card>();
			ReturnAllCards();
		}

		public int RemainingCards()
		{
			return cards.Count;
		}

		public Card GetNextCard()
		{
			if (cards.Count == 0)
			{
				Shuffle();
			}

			Card c = cards[0];
			cards.RemoveAt(0);
			return c;
		}

		public void ReturnCardToDeck(Card card)
		{
			returnedCards.Add(card);
		}

		public void Shuffle()
		{
			if (returnedCards.Count != 0)
			{
				for (int i = 0; i < returnedCards.Count; i++)
				{
					cards.Add(returnedCards[i]);
				}
			}
			returnedCards.Clear();

			Random random = new Random();
			for (int j = 0; j < 5; j++)
			{
				for (int i = 0; i < cards.Count; i++)
				{
					int rand = random.Next(0, cards.Count - 1);
					(cards[i], cards[rand]) = (cards[rand], cards[i]);
				}
			}
		}

		public void ReturnAllCards()
		{
			cards.Clear();
			returnedCards.Clear();
			for (int i = 0; i <= Convert.ToInt32(CardSuit.Diamonds); i++)
			{
				for (int j = 1; j <= Convert.ToInt32(CardFace.King); j++)
				{
					cards.Add(new Card((CardSuit)i, (CardFace)j));
				}
			}
		}

		private List<Card> cards;
		private readonly List<Card> returnedCards;
	}
}
