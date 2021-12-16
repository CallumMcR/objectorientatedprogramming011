using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class GenerateCoins
    {
        private int coins = 10000;
        public void addCoin(Object stateinfo)
        {
            coins++;
        }
        public int getCoins()
        {
            return coins;
        }

        public void removeCoins(int amount)
        {
            coins -= amount;
        }
    }
}
