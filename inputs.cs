using System;
using System.Collections.Generic;

namespace PalletExcel
{
    public class Input
    {
        public static Dictionary<string, int> products = new Dictionary<string, int>();

        public static void EnterData()
        {
            Console.WriteLine("Enter product names and quantities:");
            string productName;
            int productQty;

            while (true)
            {
                Console.WriteLine("Enter product name (or 'done' to finish):");
                productName = Console.ReadLine();
                if (productName == "done")
                {
                    break;
                }
                Console.WriteLine("Enter product quantity:");
                productQty = Convert.ToInt32(Console.ReadLine());
                products.Add(productName, productQty);
            }

            Console.WriteLine("Data entered successfully.");
        }
    }
}
