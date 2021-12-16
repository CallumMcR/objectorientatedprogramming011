using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    abstract class EdibleItem:Item,IItemDisplayDetails
    {
        protected int healAmount { get; set; }
        protected double hungerAmount { get; set; }

        protected int hungerReplenishTime { get; set; }

        public void displayDetails()
        {
            Console.WriteLine($"Item Name: {itemName}\n - Healing amount: {healAmount}\n - Hunger reduction: {hungerAmount}\n - Quantity: {quantity}\n");
        }

        public void displayDetailsForShop()
        {
            Console.WriteLine($"Item Name: {itemName} - {price} coins\n - Healing amount: {healAmount}\n - Hunger reduction: {hungerAmount}\n - Number of uses {quantity}");
        }
        public override bool useItem(List<Animal> animals, int updateInterval, Type typeOfItem, GenerateCoins coins)
        {
            Animal animal = AnimalMenu.selectAnimalToUseItemOn(animals, uniqueID, typeOfItem, coins,updateInterval);
            // The above function is ran to check if we have multiple pets, if not it will automatically select the only pet we have
            hungerReplenishTime=AnimalHunger.calculateHungerTime(animal,hungerReplenishTime); // The time to eat is changed according to the animals mood
            
            ParameterizedThreadStart decreaseHunger = new ParameterizedThreadStart(feedOverTime); //  Creates a paramaterised thread to feed the animal over time

            Thread startFeedingPet = new Thread(decreaseHunger);// Creates the thread 

            startFeedingPet.Start(animal);// Initiates the thread
            animal.health = Math.Clamp(animal.health + healAmount, 0, 100); // Ensure that the health of the animal won't exceed 100, or go below 0 when health is added
            if (quantity > 1) // Check if we need to remove item
            {
                quantity -= 1;
                return false; // Item does not need removing
            }
            else
            {
                return true; // Item needs removing
            }

        }


        public void feedOverTime(object selectedAnimal)
        {
            Animal animal = (Animal)selectedAnimal;// Convert the object to an animal class
            for (int i = 0; i < hungerReplenishTime; i++) // Everytime the thread cycles back through we want to check that we haven't gone past the number of seconds
            {
                animal.hunger = Math.Clamp(animal.hunger - (hungerAmount / hungerReplenishTime), 0, 100);
                Thread.Sleep(1000);
            }
        }
    }
}
