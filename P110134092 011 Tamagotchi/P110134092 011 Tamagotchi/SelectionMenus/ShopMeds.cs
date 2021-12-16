using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace P110134092_011_Tamagotchi
{
    class ShopMeds
    {
        public static void browse(GenerateCoins coin, List<Item> inventory, List<Animal> animals, List<MedicalItem> medItems, int updateInterval)
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
                    if (i == 1 && medItems.ElementAtOrDefault(0) != null)// Check the index exists
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        StandardMessages.print($"You are currently on ID: {curItemIndex + 1}/{medItems.Count}");
                        (medItems[curItemIndex]).displayDetailsForShop();
                        Console.ResetColor();
                    }
                    else
                    {
                        if (medItems.ElementAtOrDefault((curItemIndex + i) - 1) != null) // Check the index exists so we get no errors
                        {
                            StandardMessages.print($"ID: {curItemIndex + i}");
                            (medItems[(curItemIndex + i) - 1]).displayDetailsForShop();
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
                            if (curItemIndex < medItems.Count - 1)
                            {
                                curItemIndex++;
                            }
                        }
                        else if (keyInput.Key == ConsoleKey.Enter)
                        {
                            if (coin.getCoins() >= medItems[curItemIndex].price)
                            {
                                coin.removeCoins(medItems[curItemIndex].price); // Deduct the price of the item from the users number of coins
                                inventory.Add(medItems[curItemIndex]); // Add to the users inventory
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
