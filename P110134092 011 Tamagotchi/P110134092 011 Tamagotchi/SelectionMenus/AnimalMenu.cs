using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class AnimalMenu
    {
        public static Animal selectAnimalToUseItemOn(List<Animal> animals, string itemUniqueID, Type item, GenerateCoins coin,int updateInterval)
        { 
            int curIndex = 0;
            while (true)
            {
                StandardMessages.clearChat();
                StandardMessages.print($"Coins: {coin.getCoins()}\n");
                DisplayAnimalStats.Print(animals); // Always having the animals stats visible
                if (animals.Count>1)
                {
                    StandardMessages.writeBrowsingControls(); // Instructions for how to play
                    List<int> indexOfAnimalsWhoCanUseItem = new List<int>();
                    if (item.IsSubclassOf(typeof(RecreationalItem))) // Check the item being used is a toy
                    {
                        for (int i = 0; i < animals.Count; i++) // Go through each animal in the animals list
                        {
                            if (animals[i].useableItems.Contains(itemUniqueID))// if the animal can use the selected toy
                            {
                                indexOfAnimalsWhoCanUseItem.Add(i); // Add them to a new list of all the animals who can use that toy
                            }
                        }


                        for (int i = 1; i <= 3; i++)
                        {
                            if (i == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow; // Changing colour helps indicate the selected item
                                StandardMessages.print($"You are currently on ID: {curIndex + 1}/{indexOfAnimalsWhoCanUseItem.Count}");
                                StandardMessages.print($"{animals[indexOfAnimalsWhoCanUseItem[curIndex]].name} the {animals[indexOfAnimalsWhoCanUseItem[curIndex]].animalType}\n");
                                // We show the animals who can only use the item by showing each animal from the list of animals able to use the item by the index 
                                // of the users navigation

                                Console.ResetColor();
                            }
                            else if (curIndex + i - 1 <indexOfAnimalsWhoCanUseItem.Count)
                            {
                                StandardMessages.print($"ID: {curIndex + i}");
                                StandardMessages.print($"{animals[indexOfAnimalsWhoCanUseItem[curIndex + i - 1]].name} the {animals[indexOfAnimalsWhoCanUseItem[curIndex + i - 1]].animalType}\n");
                                // We show the animals who can only use the item by showing each animal from the list of animals able to use the item by the index 
                                // of the users navigation
                            }

                        }
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInput = Console.ReadKey();
                            if (keyInput.Key != ConsoleKey.Escape)
                            {
                                if (keyInput.Key == ConsoleKey.UpArrow)
                                {
                                    if (curIndex - 1 >= 0)
                                    {
                                        curIndex--;
                                    }

                                }
                                else if (keyInput.Key == ConsoleKey.DownArrow)
                                {
                                    if (curIndex < indexOfAnimalsWhoCanUseItem.Count - 1)
                                    {
                                        curIndex++;
                                    }
                                }
                                else if (keyInput.Key == ConsoleKey.Enter)
                                {
                                    return animals[indexOfAnimalsWhoCanUseItem[curIndex]];
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else // If the item is not a toy
                    {
                        for (int i = 1; i <= 3; i++) // This is so 3 items are displayed at max
                        { 

                            if (i == 1) // The first item will be the selected one, so we want the colour different so the user knows they have it selected
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow; // Changing colour helps indicate the selected item
                                StandardMessages.print($"You are currently on ID: {curIndex + 1}/{animals.Count}"); // index+1 is because we dont want position 0 to be shown
                                // We want a value that is more readable to the user
                                StandardMessages.print($"{animals[curIndex].name} the {animals[curIndex].animalType}\n");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (animals.ElementAtOrDefault((curIndex + i) - 1) != null)
                                {
                                    StandardMessages.print($"ID: {curIndex + i}");
                                    StandardMessages.print($"{animals[curIndex + i - 1].name} the {animals[curIndex + i - 1].animalType}\n");
                                }

                            }
                            
                        }
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInput = Console.ReadKey();
                            if (keyInput.Key != ConsoleKey.Escape)
                            {
                                if (keyInput.Key == ConsoleKey.UpArrow)
                                {
                                    if (curIndex - 1 >= 0)
                                    {
                                        curIndex--;
                                    }

                                }
                                else if (keyInput.Key == ConsoleKey.DownArrow)
                                {
                                    if (curIndex < animals.Count - 1)
                                    {
                                        curIndex++;
                                    }
                                }
                                else if (keyInput.Key == ConsoleKey.Enter)
                                {
                                    return animals[curIndex]; // Returns the animal we want to use the item on
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    
                    Thread.Sleep(updateInterval);
                }
                else // If we only have one animal
                {
                    if (item.IsSubclassOf(typeof(RecreationalItem)))
                    {
                        if (animals[0].useableItems.Contains(itemUniqueID)) // Check the animal can use the toy
                        {
                            return animals[0]; // return the animal
                        }
                    }
                    break; // Otherwise, cancel returning the animal so nothing happens
                }
                
            }
            return animals[0]; // If the item is universally useable and we only have one animal, return the first animal in the list of animals


        }
    }
}
