using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Player : Dealer
    {
        private int chipBalance;

        public Player(int chipBalance) : base()
        {
            this.chipBalance = chipBalance;
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
    }
}
