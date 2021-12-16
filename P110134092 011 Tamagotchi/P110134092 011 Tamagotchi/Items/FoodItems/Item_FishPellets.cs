using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_FishPellets : EdibleItem
    {
        public Item_FishPellets()
        {
            uniqueID = "item_food_fishpellets";
            itemName = "Fish Pellets";
            price = 20;
            quantity = 20;
            healAmount = 0;
            hungerAmount = 10;
            hungerReplenishTime = 4;
        }
    }
}
