using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            initializeDeck();
            shuffle();
        }

        private void shuffle()
        {
            // http://en.wikipedia.org/wiki/Fisher-Yates_shuffle#The_modern_algorithm
            Random rnd = new Random();
            for (int i = cards.Count - 1; i > 1; i--)
            {
                int j = rnd.Next(i + 1);
                Card swapCard = cards[j];
                cards[j] = cards[i];
                cards[i] = swapCard;
            }
        }

        private void initializeDeck()
        {
            cards = new List<Card>();
            for (int i = 1; i < 14; i++) // ranks - Ace (1) to King (13)
            {
                for (int j = 1; j < 5; j++) // suits
                {
                    cards.Add(new Card(i, j));
                }
            }
        }

        internal Card getNextCard()
        {
            int index = cards.Count - 1; // remove the last card
            Card drawnCard = cards.ElementAt(index);
            cards.RemoveAt(index);
            return drawnCard;
        }

    }
}
