using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class DisplayAnimalStats
    {
        public static void Print(List<Animal> animals)
        {
            foreach (IDisplay animal in animals)
            {
                animal.displayStats();
            }
        }
    }
}
