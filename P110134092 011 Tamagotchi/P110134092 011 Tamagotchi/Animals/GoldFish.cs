using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class GoldFish : Animal, IDisplay
    {
        private readonly List<string> listOfUseableItems = new List<string> { "item_rec_underwaterhoop" };
        public override List<string> useableItems { get { return listOfUseableItems; } }

        public GoldFish(string petName) : base(petName)
        {
            ambientTemp = 10;
            hungerInterval = 2000;
            animalType = "Goldfish";
        }


        public void display()
        {
            Console.WriteLine($"Animal Type:{animalType}\n" +
                $"Animal Name: {name}\n");
        }

        public void displayStats()
        {
            StandardMessages.print($"{name} the {animalType}\nHealth: {health}\nHunger: {Math.Round(hunger, 0)}\nMoodiness: {mood}\nTemperature: {curTemp}\n");
        }




    }
}
