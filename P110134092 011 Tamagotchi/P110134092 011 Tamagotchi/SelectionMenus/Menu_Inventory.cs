using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace P110134092_011_Tamagotchi
{
    class Menu_Inventory
    {
        public static void selectItemToUseFrom(List<Item> inventory, List<Animal> animals, int updateInterval,GenerateCoins coin)
        {
            int curItemIndex = 0;
            while (true)
            {
                StandardMessages.clearChat();
                StandardMessages.print($"Coins: {coin.getCoins()}\n");
                DisplayAnimalStats.Print(animals);
                StandardMessages.writeBrowsingControls();
                for(int i=1;i <=3;i++)
                {
                    if(i==1 && inventory.ElementAtOrDefault(0) != null) // Check that we actually have an item
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Change colour to show the selected item
                        StandardMessages.print($"You are currently on ID: {curItemIndex+1}/{inventory.Count}");
                        ((IItemDisplayDetails)inventory[curItemIndex]).displayDetails();// Display the items details
                        Console.ResetColor();
                    }
                    else
                    {
                        if(inventory.ElementAtOrDefault((curItemIndex + i) - 1) != null) // If the index = i exists, do the following, otherwise do not
                        {
                            StandardMessages.print($"ID: {curItemIndex + i}");
                            ((IItemDisplayDetails)inventory[(curItemIndex + i) - 1]).displayDetails();
                        }
                        
                    } 
                }

                
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInput = Console.ReadKey();
                    if (keyInput.Key != ConsoleKey.Escape)
                    {
                        if(keyInput.Key == ConsoleKey.UpArrow)
                        {
                            if(curItemIndex-1 >= 0)
                            {
                                curItemIndex--;
                            }
                            
                        }
                        else if (keyInput.Key == ConsoleKey.DownArrow)
                        {
                            if(curItemIndex < inventory.Count-1)
                            {
                                curItemIndex++;
                            }
                        }
                        else if (keyInput.Key== ConsoleKey.Enter && inventory.Count>0)
                        {
                            bool oneAnimalCanUseToy = false;
                            if(inventory[curItemIndex].GetType().IsSubclassOf(typeof(RecreationalItem))) // If the item selected is a toy
                            {
                                foreach (Animal animal in animals) // Loop through each animal
                                {
                                    if (animal.useableItems.Contains(inventory[curItemIndex].uniqueID)) // If the animals listOfUseableItems attribute contains the
                                        // uniqueID of this item, then set the boolean to true, otherwise it can remain false
                                    {
                                        oneAnimalCanUseToy = true;
                                    }
                                }
                                if (oneAnimalCanUseToy) // If true
                                {
                                    bool shouldDelete = inventory[curItemIndex].useItem(animals, updateInterval, inventory[curItemIndex].GetType(), coin);
                                    // Use the item (which returns true or false to indicate whether to delete the item)
                                    if (shouldDelete == true)
                                    {
                                        inventory.RemoveAt(curItemIndex); // Delete the item if so
                                    }
                                }
                            }
                            else
                            {
                                bool shouldDelete = inventory[curItemIndex].useItem(animals, updateInterval, inventory[curItemIndex].GetType(), coin);
                                // Use the item if it is not a toy
                                if (shouldDelete == true)
                                {
                                    inventory.RemoveAt(curItemIndex); // Delete from inventory if we dont need it
                                }
                            }

                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Thread.Sleep(updateInterval);
                
            }
            
        }
    }
}
