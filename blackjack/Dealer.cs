using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Dealer
    {
        public List<Card> hand;

        public Dealer()
        {
            this.hand = new List<Card>();
        }

        internal void getCard(Card newCard)
        {
            this.hand.Add(newCard);
        }

        internal void resetHand()
        {
            this.hand = new List<Card>();
        }

        internal int getScore()
        {
            int totalScore = 0;
            int acesUsed = 0;

            // Add up card ranks
            foreach (Card c in hand)
            {
                if (c.getRank() > 10)
                    totalScore += 10;
                else
                    totalScore += c.getRank();
                if (c.getRank() == 1) // if Ace
                {
                    totalScore += 10;
                    acesUsed++;
                }
            }

            // reduce value of Aces as needed to stay under bust limit
            while (acesUsed > 0 && totalScore > 21)
            {
                acesUsed--;
                totalScore -= 10;
            }

            return totalScore;
        }
    }
}
