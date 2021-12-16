using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class SelectTamagotchi
    {
        public static void fromChoiceOf(List<Animal> animals, int updateInterval)
        {
            List<Animal> uniqueSpecies = GenerateList.OfDifferentAnimalSpecies(); // Create a list of all the different subclasses of animals, this way we can display
            // What animals the user can select to use
            
            int curIndex = 0;
            while(true)
            {
                StandardMessages.clearChat();
                StandardMessages.writeBrowsingControlsForPet();
                for (int i = 1; i <= 3; i++)
                {
                    if (i == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        StandardMessages.print($"You are currently on ID: {curIndex + 1}/{uniqueSpecies.Count}");
                        StandardMessages.print($"Animal species: {uniqueSpecies[curIndex].animalType}");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (uniqueSpecies.ElementAtOrDefault((curIndex + i) - 1) != null) // If this index exists in the list
                        {
                            StandardMessages.print($"ID: {curIndex + i}");
                            StandardMessages.print($"Animal species: {uniqueSpecies[(curIndex+i)-1].animalType}"); // Display the animals species to the user
                        }

                    }
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInput = Console.ReadKey();

                    if (keyInput.Key == ConsoleKey.UpArrow)
                    {
                        if (curIndex - 1 >= 0)
                        {
                            curIndex--;
                        }

                    }
                    else if (keyInput.Key == ConsoleKey.DownArrow)
                    {
                        if (curIndex < uniqueSpecies.Count - 1)
                        {
                            curIndex++;
                        }
                    }
                    else if (keyInput.Key == ConsoleKey.Enter)
                    {
                        Animal selectedAnimal = uniqueSpecies[curIndex]; // Set the chosen animal to equal the object in the list of uniqueSpecies
                        Type typeOfAnimal = uniqueSpecies[curIndex].GetType();
                        string petName = StandardMessages.userInput($"Please type the name of your pet {selectedAnimal.animalType}:\n");
                        animals.Add((Animal)Activator.CreateInstance(typeOfAnimal, petName)); // Create a new instance of the selected type of animal and add its pet name
                    }
                    else if (keyInput.Key == ConsoleKey.Escape && animals.Count >= 1)
                    {
                        break;// return to the main menu
                    }
                }
                Thread.Sleep(updateInterval);
            }
            

            

        }
    }
}
