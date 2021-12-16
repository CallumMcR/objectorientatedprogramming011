using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Threading;

namespace P110134092_011_Tamagotchi
{
    class Application
    {
        private List<Animal> animals = new List<Animal>();
        private List<Item> inventory = new List<Item>();
        
        int updateInterval = 250; // Changing this changes the refresh rate of the program
        public void StartApp()
        {
            SelectTamagotchi.fromChoiceOf(animals, updateInterval);
            AnimalStatisticTimers.Initiate(animals);
            RoomTemperature room = new RoomTemperature(animals);
            GenerateCoins coin = new GenerateCoins();
             // Initalising timers
            Timer coinTimer = new Timer(new TimerCallback(coin.addCoin), null, 0,1000);
            Timer roomDecreaseTempTimer = new Timer(new TimerCallback(room.decreaseTemperature), null, Timeout.Infinite, Timeout.Infinite);
            Timer roomIncreaseTempTimer = new Timer(new TimerCallback(room.increaseTemperature), null, Timeout.Infinite, Timeout.Infinite);

            bool program = true;
            while (program)
            {
                StandardMessages.clearChat();
                StandardMessages.print($"Coins: {coin.getCoins()}\n");
                DisplayAnimalStats.Print(animals);
                StandardMessages.writeMainMenuOptions();
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo keyInput = Console.ReadKey();
                    if (keyInput.Key != ConsoleKey.Escape)
                    {
                        
                        if (int.TryParse(keyInput.KeyChar.ToString(), out int number) && number != 0)
                        {
                            int menuSelect = number;
                            StandardMessages.clearChat();
                            if (menuSelect == 1)
                            {
                                Menu_Inventory.selectItemToUseFrom(inventory, animals, updateInterval,coin); // Pick which item we want to use from our inventory
                            }
                            else if (menuSelect == 2) // Increase temperature
                            {
                                roomDecreaseTempTimer.Change(Timeout.Infinite, Timeout.Infinite);
                                roomIncreaseTempTimer.Change(0, 1000);

                            }
                            else if (menuSelect == 3) // Decrease Temperature
                            {
                                roomIncreaseTempTimer.Change(Timeout.Infinite, Timeout.Infinite);
                                roomDecreaseTempTimer.Change(0, 1000);
                            }
                            else if (menuSelect == 4) // Open shop menu
                            {
                                Shop.Menu(inventory, coin,animals,updateInterval);
                            }
                        }
                    }
                }
                RemoveDeadAnimals.From(animals);
                if(animals.Count==0)
                {
                    program = false;
                }
                Thread.Sleep(updateInterval);
            }
            StandardMessages.clearChat();
            StandardMessages.print("All your pets have sadly passed away");
            Console.ReadLine();
        }
        

    }
}
