using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class AnimalStatisticTimers
    {

        public static void Initiate(List<Animal> animals)
        {
            foreach (Animal animal in animals) // Create all the essential timers for each animal
            {
                Timer animalHunger = new Timer(new TimerCallback(animal.increaseHunger), null, 0, animal.hungerInterval);
                Timer animalMood = new Timer(new TimerCallback(animal.makeMoodier), null, 0, 2000);
                Timer animalStarvationCalculator = new Timer(new TimerCallback(animal.decreaseHealth), null, 0, 1000);
                Timer animalHealthByTemperature = new Timer(new TimerCallback(animal.decreaseHealthFromTemperature), null, 0, 5000);
            }

        }

        


    }
}
