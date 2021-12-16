using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class ShopToys
    {
        public static void browse(GenerateCoins coin, List<Item> inventory, List<Animal> animals, List<RecreationalItem> recItems, int updateInterval)
        {
            int curItemIndex = 0;
            while(true)
            {
                StandardMessages.clearChat();
                StandardMessages.print($"Coins: {coin.getCoins()}\n");
                DisplayAnimalStats.Print(animals);

                StandardMessages.writeBrowsingControls();
                for (int i = 1; i <= 3; i++)
                {
                    if (i == 1 && recItems.ElementAtOrDefault(0) != null) // Check the item at this index exists
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; 
                        StandardMessages.print($"You are currently on ID: {curItemIndex + 1}/{recItems.Count}");
                        (recItems[curItemIndex]).displayDetailsForShop();
                        Console.ResetColor();
                    }
                    else
                    {
                        if (recItems.ElementAtOrDefault((curItemIndex + i) - 1) != null)// Check the item at this index exists
                        {
                            StandardMessages.print($"ID: {curItemIndex + i}");
                            (recItems[(curItemIndex + i) - 1]).displayDetailsForShop();
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
                            if (curItemIndex < recItems.Count - 1)
                            {
                                curItemIndex++;
                            }
                        }
                        else if (keyInput.Key == ConsoleKey.Enter)
                        {
                            if (coin.getCoins() >= recItems[curItemIndex].price)
                            {
                                coin.removeCoins(recItems[curItemIndex].price);
                                inventory.Add(recItems[curItemIndex]);
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
