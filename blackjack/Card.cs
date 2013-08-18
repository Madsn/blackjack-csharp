using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blackjack
{
    class Card
    {
        int rank;
        int suit;

        public Card(int rank, int suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        internal int getRank()
        {
            return this.rank;
        }

        internal int getSuit()
        {
            return this.suit;
        }

        public override string ToString()
        {
            return this.getRankAsString() + " of " + this.getSuitAsString();
        }

        internal string getSuitAsString()
        {
            switch (this.suit)
            {
                case 1:
                    return "Clubs";
                case 2:
                    return "Diamonds";
                case 3:
                    return "Hearts";
                case 4:
                    return "Spades";
                default:
                    throw new Exception(string.Format("Unknown suit: {0}", this.suit));
            }
        }

        internal string getRankAsString()
        {
            switch (this.rank)
            {
                case 1:
                    return "Ace";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return this.rank.ToString();
            }
        }
    }
}
