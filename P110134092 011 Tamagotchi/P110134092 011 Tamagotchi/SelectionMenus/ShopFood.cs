using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace P110134092_011_Tamagotchi
{
    class ShopFood
    {
        public static void browse(GenerateCoins coin, List<Item> inventory, List<Animal> animals, List<EdibleItem> foodItems, int updateInterval)
        {
            int curItemIndex = 0;
            while (true)
            {
                StandardMessages.clearChat();
                StandardMessages.print($"Coins: {coin.getCoins()}\n");
                DisplayAnimalStats.Print(animals);

                StandardMessages.writeBrowsingControls();
                for (int i = 1; i <= 3; i++)
                {
                    if (i == 1 && foodItems.ElementAtOrDefault(0) != null) // Check that the item at this index exists
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        StandardMessages.print($"You are currently on ID: {curItemIndex + 1}/{foodItems.Count}");
                        (foodItems[curItemIndex]).displayDetailsForShop();
                        Console.ResetColor();
                    }
                    else
                    {
                        if (foodItems.ElementAtOrDefault((curItemIndex + i) - 1) != null) // Check that this index exists
                        {
                            StandardMessages.print($"ID: {curItemIndex + i}");
                            (foodItems[(curItemIndex + i) - 1]).displayDetailsForShop();
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
                            if (curItemIndex - 1 >= 0)
                            {
                                curItemIndex--;
                            }

                        }
                        else if (keyInput.Key == ConsoleKey.DownArrow)
                        {
                            if (curItemIndex < foodItems.Count - 1)
                            {
                                curItemIndex++;
                            }
                        }
                        else if (keyInput.Key == ConsoleKey.Enter)
                        {
                            if (coin.getCoins() >= foodItems[curItemIndex].price)// Check the user has enough coins
                            {
                                coin.removeCoins(foodItems[curItemIndex].price); // Deduct the price of the item from the users number of coins
                                inventory.Add(foodItems[curItemIndex]); // Add that item to the players inventory
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
