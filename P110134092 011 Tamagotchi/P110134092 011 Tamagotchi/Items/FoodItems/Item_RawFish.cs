using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_RawFish:EdibleItem
    {
        public Item_RawFish()
        {
            uniqueID = "item_food_rawfish";
            itemName = "Raw Fish";
            price = 50;
            quantity = 1;
            healAmount = 5;
            hungerAmount = 40;
            hungerReplenishTime = 8;
        }
    }
}
