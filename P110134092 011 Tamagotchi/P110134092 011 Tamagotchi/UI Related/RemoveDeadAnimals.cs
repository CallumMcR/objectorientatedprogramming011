using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class RemoveDeadAnimals
    {
        public static void From(List<Animal> animals)
        {
            for (int i=animals.Count-1;i>=0;i--)
            {
                if (animals[i].health <= 0)
                {
                    animals.Remove(animals[i]); // Delete any animals that are dead and the user is no longer able to interact with
                }
            }
        }
    }
}
