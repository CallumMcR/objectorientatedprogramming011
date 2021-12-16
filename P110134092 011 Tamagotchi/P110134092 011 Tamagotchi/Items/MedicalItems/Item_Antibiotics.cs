using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_Antibiotics : MedicalItem
    {
        public Item_Antibiotics()
        {
            uniqueID = "item_med_antibiotics";
            itemName = "Antibiotics";
            price = 500;
            quantity = 10;
            healAmount = 50;
            hungerAmount = -10;
            hungerReplenishTime = 10;// Seconds
        }
    }
}
