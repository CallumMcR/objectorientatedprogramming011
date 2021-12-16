using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class Beaver: Animal, IDisplay
    {
        // This is a list of items the animal can use
        private readonly List<string> listOfUseableItems = new List<string> { "item_rec_ball"};
        public override List<string> useableItems { get { return listOfUseableItems; } } 

        public Beaver(string petName) : base(petName)
        {
            ambientTemp = 32;
            hungerInterval = 2000;
            animalType = "Beaver";
        }


        public void display()
        {
            Console.WriteLine($"Animal Type:{animalType}\n" +
                $"Animal Name: {name}\n");
        }

        public void displayStats()
        {
            StandardMessages.print($"{name} the {animalType}\nHealth: {health}\nHunger: {Math.Round(hunger,0)}\nMoodiness: {mood}\nTemperature: {curTemp}\n");
        }

        


    }
}
