using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class CalculateRoomTemperature
    {
        public static decimal findAverageAmbientTemp(List<Animal> animals)
        {
            if (animals.Count>1) // If we have multiple animals, calculate an average temperature for the room
            {
                decimal animTotalTemp = 0;
                foreach (Animal animal in animals)
                {
                    animTotalTemp += animal.ambientTemp;
                }
                return animTotalTemp / animals.Count;
            } // Otherwise, just return our 1 animals ambient temp
            return animals[0].ambientTemp;
            
        }
    }
}
