using System;
using System.Collections.Generic;
using System.Text;

namespace P110134092_011_Tamagotchi
{
    class StandardMessages
    {
        public static string userInput(string statement)
        {
            Console.WriteLine(statement);
            string input = Console.ReadLine();
            return input;
        }

        public static void print(string statement)
        {
            Console.WriteLine(statement);
        }

        public static void clearChat()
        {
            Console.Clear();
        }
        public static void writeMainMenuOptions()
        {
            Console.WriteLine($"1. Use/view items in your inventory\n" +
                    $"2. Increase room temperature\n" +
                    $"3. Decrease room temperature\n" +
                    $"4. Shop\n");
        }

        public static void writeBrowsingControls()
        {
            Console.WriteLine("Press Esc to return to main menu, down/up arrow to go through items and ENTER to select the yellow text item");
        }

        public static void writeBrowsingControlsForPet()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Press Esc once you have chosen atleast one pet, down/up arrow to filter through pets and ENTER to select the the pet in yellow - you can choose multiple\n");
            Console.ResetColor();
        }
    }
}
