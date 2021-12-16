using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class Penguin: Animal,IDisplay
    {
        private readonly List<string> listOfUseableItems = new List<string> { "item_rec_underwaterhoop","item_rec_ball" }; 
        public override List<string> useableItems { get { return listOfUseableItems; } } 
        public Penguin(string petName) : base(petName)
        {
            ambientTemp = 4;
            hungerInterval = 2000;
            animalType = "Penguin";
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
