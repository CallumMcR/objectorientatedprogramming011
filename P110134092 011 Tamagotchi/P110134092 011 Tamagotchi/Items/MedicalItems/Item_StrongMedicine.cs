using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_StrongMedicine : MedicalItem
    {
        public Item_StrongMedicine()
        {
            uniqueID = "item_med_strongmedicine";
            itemName = "Strong Medicine";
            price = 250;
            quantity = 1;
            healAmount = 40;
            hungerAmount = 50;
            hungerReplenishTime = 5;// Seconds
        }
    }
}
