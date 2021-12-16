using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_UnderwaterHoop : RecreationalItem
    {

        public Item_UnderwaterHoop()
        {
            uniqueID = "item_rec_underwaterhoop";
            itemName = "Underwater Hoop";
            price = 200;
            quantity = 10;
            depleteMoodValue = 5;

        }
    }
}
