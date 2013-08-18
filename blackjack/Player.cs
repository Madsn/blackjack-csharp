using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Player
    {
        private int chipBalance;
        public List<Card> hand;

        public Player(int chipBalance)
        {
            this.chipBalance = chipBalance;
            this.hand = new List<Card>();
        }

        internal int getChipBalance()
        {
            return this.chipBalance;
        }

        internal void loseChips(int diff)
        {
            this.chipBalance -= diff;
        }

        internal void obtainChips(int diff)
        {
            this.chipBalance += diff;
        }

        internal void getCard(Card newCard)
        {
            this.hand.Add(newCard);
        }

        internal void resetHand()
        {
            this.hand = new List<Card>();
        }

        internal object getScore()
        {
            int totalScore = 0;
            int acesUsed = 0;

            // Add up card ranks
            foreach (Card c in hand)
            {
                totalScore += c.getRank();
                if (c.getRank() == 1) // if Ace
                {
                    totalScore += 13;
                    acesUsed++;
                }
            }

            // reduce value of Aces as needed to stay under bust limit
            while (acesUsed > 0 && totalScore > 21)
            {
                acesUsed--;
                totalScore -= 13;
            }

            return totalScore;
        }
    }
}
