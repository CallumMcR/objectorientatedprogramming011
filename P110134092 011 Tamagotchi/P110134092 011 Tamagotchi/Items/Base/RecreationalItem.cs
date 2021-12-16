using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    abstract class RecreationalItem:Item, IItemDisplayDetails
    {
        protected int depleteMoodValue { get; set; }
        public void displayDetails()
        {
            Console.WriteLine($"Item Name: {itemName}\n - Decrease moodiness by: {depleteMoodValue}\n - Quantity {quantity}\n");
        }

        public void displayDetailsForShop()
        {
            Console.WriteLine($"Item Name: {itemName} - {price} coins\n - Decrease moodiness by: {depleteMoodValue}\n - Number of uses: {quantity}");
        }


        public override bool useItem(List<Animal> animals,int updateInterval, Type typeOfItem, GenerateCoins coins)
        {
            Animal animal = AnimalMenu.selectAnimalToUseItemOn(animals, uniqueID, typeOfItem, coins,updateInterval);
            animal.mood = Math.Clamp(animal.mood-depleteMoodValue,0,100);// Change mood value, and if the value exceeds 100, or less than 0, then change the value to 0 or 100
            
            if (quantity > 1)
            {
                quantity -= 1;
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
