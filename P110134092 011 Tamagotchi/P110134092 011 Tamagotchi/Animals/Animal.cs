using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    abstract class Animal
    {
        public string name { get; set; }

        public int health { get; set; }

        public double hunger { get; set; }

        public int mood { get; set; }

        public string sprite { get; set; }

        public decimal ambientTemp { get; set; }

        public decimal curTemp { get; set; }

        public string animalType { get; set; }

        public int hungerInterval { get; set; }

        public virtual List<string> useableItems { get; set; }


        public Animal(string petName)
        {
            name = petName;
            health = 100;
            hunger = 0;
            mood = 0;
            curTemp = 20;
        }

        
        public void increaseHunger(object stateinfo) // This method is used to increase the animals hunger throughout
        {
            hunger = Math.Clamp(hunger+1,0,100); // Prevents the hunger raising above the 100 mark
        }

        public void makeMoodier(object stateinfo) // This method is used to increase the mood of the animal throughout
        {      
            mood = Math.Clamp(mood + 1, 0, 100); // Prevents the mood raising above the 100 mark
        }

        public void decreaseHealth(object stateinfo) // This method decreases the animals health when it meets the required conditions
        {
            
            if (hunger ==100)
            {
                health = Math.Clamp(health - 2, 0, 100);
            }
            else if (hunger >= 80)
            {
                health = Math.Clamp(health - 1, 0, 100);
            }
 
        }

        public void decreaseHealthFromTemperature(object stateinfo) // Decreases health unless the animals temperature is within a quarter above/below its ambient temperature
        {
            if (curTemp < (0.75m * ambientTemp))
            {
                health = Math.Clamp(health - 1, 0, 100); // Make sure the health cant go below 0, or above 100
            }
            else if(curTemp > 1.25m*ambientTemp)
            {
                health = Math.Clamp(health - 1, 0, 100);
            }
        }
    }
}
