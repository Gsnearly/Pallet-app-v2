using System;

namespace PalletExcel
{
    static class Menu
    {
        public static int Display()
        {
            Console.WriteLine("Welcome to PalletExcel!");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Enter product data");
            Console.WriteLine("2. Export to Excel");
            Console.WriteLine("3. create folder");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }

            return choice;
        }
    }
}
