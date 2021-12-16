using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    abstract class Item
    {
        public string uniqueID { get; set; }

        protected string itemName { get; set; }
        
        public int price { get; set; }

        protected int quantity { get; set; }


        public virtual bool useItem(List<Animal> animals, int updateInterval, Type typeOfItem, GenerateCoins coins)
        {
            return true;
        }


    }
}
