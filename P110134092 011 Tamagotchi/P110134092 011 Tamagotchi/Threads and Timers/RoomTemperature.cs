using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class RoomTemperature
    {

        private List<Animal> animals { get; }

        private bool tempIncreasing { get; set; }
        private bool tempDecreasing { get; set; }
        public RoomTemperature(List<Animal> listOfAnimals)
        {
            animals = listOfAnimals;
            tempDecreasing = false;
            tempIncreasing = false;
        }


        public void increaseTemperature(object stateinfo)
        {
            if (tempDecreasing)
            {
                tempDecreasing = false; // Stop decreasing the room temperature
                tempIncreasing = true;
            }
            foreach(Animal animal in animals)
            {
                if (animal.curTemp < CalculateRoomTemperature.findAverageAmbientTemp(animals))
                {
                    animal.curTemp = animal.curTemp + (decimal)0.01;
                }
            }
        }

        public void decreaseTemperature(object stateinfo)
        {
            if (tempIncreasing)
            {
                tempIncreasing = false; // Stop increasing the room temperature
                tempDecreasing = true;
            }
            foreach (Animal animal in animals)
            {
                if(animal.curTemp > CalculateRoomTemperature.findAverageAmbientTemp(animals))
                {
                    animal.curTemp = animal.curTemp - (decimal)0.01;
                }
            }
        }
    }
}
