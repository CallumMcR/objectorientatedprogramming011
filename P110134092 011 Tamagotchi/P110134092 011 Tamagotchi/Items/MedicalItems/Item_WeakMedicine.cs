using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Item_WeakMedicine:MedicalItem
    {
        public Item_WeakMedicine()
        {
            uniqueID = "item_med_weakmedicine";
            itemName = "Cheap Medicine";
            price = 50;
            quantity = 1;
            healAmount = 20;
            hungerAmount = -30;
            hungerReplenishTime = 15;// 15 seconds
        }
    }
}
