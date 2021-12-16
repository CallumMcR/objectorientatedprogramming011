using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class Shop
    {
        public static void Menu(List<Item> inventory, GenerateCoins coin, List<Animal> animals, int updateInterval)
        {
            List<MedicalItem> medItems = GenerateList.OfMedicalItems();
            List<RecreationalItem> recItems = GenerateList.OfRecreationalItems();
            List<EdibleItem> foodItems = GenerateList.OfFoodItems();
            // The above generates a list of all the items of each category
            while (true)
            {
                StandardMessages.clearChat();
                StandardMessages.print($"Coins: {coin.getCoins()}\n");
                DisplayAnimalStats.Print(animals);
                StandardMessages.print($"Choose a category to filter by:\n" +
                    $"1. Toys\n" +
                    $"2. Food\n" +
                    $"3. Medicine\n");

                StandardMessages.print("Press the ESC to return to the main menu, or one of the numbers shown on the screen to select the according option");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInput = Console.ReadKey();
                    int number;
                    if (int.TryParse(keyInput.KeyChar.ToString(), out number) && number > 0 && number < 4) // Make sure the pressed button is within the range of the
                        // number of selectable options
                    {
                        if(number==1)
                        {
                            ShopToys.browse(coin, inventory, animals,recItems,updateInterval);
                        }
                        else if(number==2)
                        {
                            ShopFood.browse(coin, inventory, animals, foodItems, updateInterval);
                        }
                        else if(number==3)
                        {
                            ShopMeds.browse(coin, inventory, animals, medItems, updateInterval);
                        }
                    }
                    else if(keyInput.Key == ConsoleKey.Escape)
                    {
                        break;
                    }


                }
                Thread.Sleep(updateInterval);
                
            }
        }
    }
}
