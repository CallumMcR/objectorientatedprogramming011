using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace P110134092_011_Tamagotchi
{
    class GenerateList
    {
        public static List<MedicalItem> OfMedicalItems()
        {
            List<MedicalItem> medItems = new List<MedicalItem>();
            foreach (Type Type in
                Assembly.GetAssembly(typeof(MedicalItem)).GetTypes()
                .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(MedicalItem)))) 
            {

                medItems.Add((MedicalItem)Activator.CreateInstance(Type));
            }
            return medItems;
        }

        public static List<RecreationalItem> OfRecreationalItems()
        {
            List<RecreationalItem> recItems = new List<RecreationalItem>();
            foreach (Type Type in
                Assembly.GetAssembly(typeof(RecreationalItem)).GetTypes()
                .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(RecreationalItem))))
            {

                recItems.Add((RecreationalItem)Activator.CreateInstance(Type));
            }
            return recItems;
        }

        public static List<EdibleItem> OfFoodItems()
        {
            List<EdibleItem> foodItems = new List<EdibleItem>();
            foreach (Type Type in
                Assembly.GetAssembly(typeof(EdibleItem)).GetTypes()
                .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(EdibleItem))))
            {
                foodItems.Add((EdibleItem)Activator.CreateInstance(Type));
            }
            return foodItems;
        }


        public static List<Animal> OfDifferentAnimalSpecies()
        {
            List<Animal> uniqueSpecies = new List<Animal>();
            foreach (Type Type in
                Assembly.GetAssembly(typeof(Animal)).GetTypes()
                .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(Animal))))
            {
                uniqueSpecies.Add((Animal)Activator.CreateInstance(Type,"Example"));
            }
            return uniqueSpecies;
        }
    }
}
