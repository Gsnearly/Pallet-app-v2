using Google.Api.Gax.ResourceNames;
using NPOI.POIFS.Properties;
using OfficeOpenXml;

namespace PalletExcel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Set license context to NonCommercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            while (true)
            {
                // Display menu and get user input
                int choice = Menu.Display();

                // Invoke function based on user input
                switch (choice)
                {
                    case 1:
                        Input.EnterData();
                        break;
                    case 2:
                        Export.ToExcel();
                        break;
                    case 3:
                        Googledrive.CreateFolder();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            }
        }
    }
}
