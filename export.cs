using System;
using System.IO;
using System.Text;
using NPOI.HPSF;
using OfficeOpenXml;

namespace PalletExcel
{
    public class Export
    {
        public static void ToExcel()
        {
            // Get user input for pallet number
            Console.WriteLine("Enter pallet number:");
            string palletNum = Console.ReadLine();

            // Create directory if it doesn't exist
            string dirName = "pallet_excel";
            if (!Directory.Exists(dirName))
            {
                try
                {
                    Directory.CreateDirectory(dirName);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error creating directory: {ex.Message}");
                    return;
                }
            }

            // Create Excel workbook and worksheet
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Pallet");

                // Write product names and quantities to worksheet
                worksheet.Cells[1, 1].Value = "Product Name";
                worksheet.Cells[1, 2].Value = "Quantity";
                int row = 2;
                foreach (KeyValuePair<string, int> product in Input.products)
                {
                    worksheet.Cells[row, 1].Value = product.Key;
                    worksheet.Cells[row, 2].Value = product.Value;
                    row++;
                }

                // Calculate total quantity
                int totalQuantity = 0;
                foreach (int quantity in Input.products.Values)
                {
                    totalQuantity += quantity;
                }

                // Add new row for total quantity
                worksheet.Cells[row, 1].Value = "Total Quantity";
                worksheet.Cells[row, 2].Value = totalQuantity;
                worksheet.Cells[row, 2].Style.Font.Bold = true;
                worksheet.Cells[row, 1, row, 2].AutoFitColumns(); // Auto-fit total row columns

                // Save Excel file with pallet number and current date
                string fileName = $"{dirName}/pallet#{palletNum}_{DateTime.Now.ToString("MM_dd_yyyy")}.xlsx";
                try
                {
                    package.SaveAs(new FileInfo(fileName));
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error saving Excel file: {ex.Message}");
                    return;
                }

                Console.WriteLine($"Excel file saved to: {Path.GetFullPath(fileName)}");



            }
        }
    }
}
