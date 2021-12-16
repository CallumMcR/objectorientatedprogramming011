using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_Medicine:MedicalItem
    {
        public Item_Medicine()
        {
            uniqueID = "item_med_medicine";
            itemName = "Medicine";
            price = 200;
            quantity = 1;
            healAmount = 20;
            hungerAmount = 10;
            hungerReplenishTime = 10;// Seconds
        }
    }
}
