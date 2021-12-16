using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_Ball:RecreationalItem
    {

        public Item_Ball()
        {
            uniqueID = "item_rec_ball";
            itemName = "Ball";
            price = 200;
            quantity = 10;
            depleteMoodValue = 3;

        }
    }
}
