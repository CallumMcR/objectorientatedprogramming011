using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class AnimalHunger
    {

        public static int calculateHungerTime(Animal animal,int hungerReplenishTime) // This method calculates how long it will take the animal to eat the food,
          // dependent on its current mood and how long it initially takes to eat
        {
            List<int> lowerQuartiles = new List<int> { 25, 50, 75, 100 };
            List<double> relativePercentageMultipliers = new List<double> { 1, 1.25, 1.5, 2 }; // These are how much we want to increase the duration by
            int i = 0;


            for (; i < lowerQuartiles.Count; i++)
            {
                if (animal.mood <= lowerQuartiles[i]) // Check if the animals current mood is less than or  equal to each of the elements in lowerQuartile
                {
                    break; // Stop the loop, this way we can use the current value of 'i' as the index position
                }
            }
            int roundedToSecs = Convert.ToInt32(Math.Round(hungerReplenishTime * relativePercentageMultipliers[i], 0));
            return roundedToSecs;
        }



    }
}
