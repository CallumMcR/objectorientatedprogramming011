using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    abstract class MedicalItem:Item, IItemDisplayDetails
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

            Console.WriteLine($"Item Name: {itemName} - {price} coins\n - Healing amount: {healAmount}\n - Hunger reduction: {hungerAmount}\n - Number of uses: {quantity}");
        }
        public override bool useItem(List<Animal> animals, int updateInterval, Type typeOfItem, GenerateCoins coins)
        {
            Animal animal = AnimalMenu.selectAnimalToUseItemOn(animals, uniqueID, typeOfItem,coins,updateInterval);
            animal.health = Math.Clamp(animal.health + healAmount, 0, 100);
            hungerReplenishTime = AnimalHunger.calculateHungerTime(animal,hungerReplenishTime);
            ParameterizedThreadStart decreaseHunger = new ParameterizedThreadStart(feedOverTime);
            Thread startFeedingPet = new Thread(decreaseHunger);
            startFeedingPet.Start(animal);

            if (quantity>1)
            {
                quantity -=1;
                return false;
            }
            else
            {
                return true; 
            }
            
        }
               

        public void feedOverTime(object selectedAnimal)
        {
            Animal animal = (Animal)selectedAnimal;
            for(int i=0;i<hungerReplenishTime;i++)
            {
                animal.hunger = Math.Clamp(animal.hunger - (hungerAmount/hungerReplenishTime),0,100);
                Thread.Sleep(1000);
            }
        }
    }
}
