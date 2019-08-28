using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab

namespace NUnit.Tests1.Utilities
{
    public class Read_From_Excel
    {
        public void getExcelFile(string file)
        {

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\bryar.h.cole\Desktop\" + file);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!

            //New Worksheet
            Excel.Application xlNewApp = new Excel.Application();
            Excel.Workbook xlNewWorkbook;
            Excel.Worksheet xlNewWorksheet;
            object misValue = System.Reflection.Missing.Value;

            xlNewWorkbook = xlNewApp.Workbooks.Add(misValue);
            xlNewWorksheet = (Excel.Worksheet)xlNewWorkbook.Worksheets.Item[1];
            Excel.Range xlNewRange = xlNewWorksheet.UsedRange;
            // row, column


            xlNewRange.Cells[6, 1].Value2 = "Test Case ID";
            xlNewRange.Cells[6, 2].Value2 = "RTM Test Scenario IDs (separated with Commas)";
            xlNewRange.Cells[6, 3].Value2 = "Test Suite ID";
            xlNewRange.Cells[6, 4].Value2 = "Title";
            xlNewRange.Cells[6, 5].Value2 = "Test Objetive";
            xlNewRange.Cells[6, 6].Value2 = "Description";
            xlNewRange.Cells[6, 7].Value2 = "Pre-Condition";
            xlNewRange.Cells[6, 8].Value2 = "Priority";
            xlNewRange.Cells[6, 9].Value2 = "Complexity";
            xlNewRange.Cells[6, 10].Value2 = "Scenario Type";
            xlNewRange.Cells[6, 11].Value2 = "Test Case Application";
            xlNewRange.Cells[6, 12].Value2 = "Test Case Application Area";
            xlNewRange.Cells[6, 13].Value2 = "Test Application Process";
            xlNewRange.Cells[6, 14].Value2 = "Test Case APplication Sub Area";
            xlNewRange.Cells[6, 15].Value2 = "Test Case Type";
            xlNewRange.Cells[6, 16].Value2 = "Steps";
            xlNewRange.Cells[6, 17].Value2 = "Actions";
            xlNewRange.Cells[6, 18].Value2 = "Expected Result";
            xlNewRange.Cells[6, 19].Value2 = "Reference Document";
            xlNewRange.Cells[6, 21].Value2 = "Reveiewer Comment";
            xlNewRange.Cells[6, 22].Value2 = "Reviewer Name";


            List<string> listOFPermissions = new List<string>();
            string[] listofP;
            int startingRow = 7;
            int totalCount = 0;
            Console.WriteLine("Row count: " + rowCount + "\n" + "Column count: " + colCount);
            string result = "";
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 2; i <= rowCount; i++)
            {
                int startingCol = 4;
                if (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null)
                {
                    string rolePermission = xlRange.Cells[i, 2].Value2.ToString();
                    string roleID = xlRange.Cells[i, 1].Value2.ToString();
                    string CellValue = "";
                    stringBuilder.Clear();
                    string role = roleID + "_" + rolePermission;
                    //Console.WriteLine("The following scenarios for: " + columnRole + "_" + rolePermission + " as follows:");
                    xlNewRange.Cells[startingRow, 4].Value2 = "TC_ITO5_Security Roles_" + roleID + "_" + rolePermission;
                    xlNewRange.Cells[startingRow, 5].Value2 = "What: To verify that the " + rolePermission + " role has the appropiate access for his/her function.\nWhy: To ensure that the system enables the user to perform his or her function according to  their role";
                    CellValue = "TC. Verify that the " + rolePermission + "with " + role + " has the following function: " + rolePermission + " which has the following permissions: ";
                    stringBuilder.Append(CellValue);
                    xlNewRange.Cells[startingRow, 6].Value2 = stringBuilder.ToString();
                    xlNewRange.Cells[startingRow, 7].Value2 = "1.Worker has valid credentials to login into worker portal.\n2.Worker has valid role ID " + roleID + " configured";
                    xlNewRange.Cells[startingRow, 8].Value2 = "3 - Medium";
                    xlNewRange.Cells[startingRow, 9].Value2 = "3 - Low";
                    xlNewRange.Cells[startingRow, 10].Value2 = "1 - Positive";
                    xlNewRange.Cells[startingRow, 11].Value2 = "Portal";
                    xlNewRange.Cells[startingRow, 12].Value2 = "Credentials";
                    xlNewRange.Cells[startingRow, 13].Value2 = "General Functions";
                    xlNewRange.Cells[startingRow, 14].Value2 = "Worker Portal";
                    xlNewRange.Cells[startingRow, 15].Value2 = "Product Test";
                    xlNewRange.Cells[startingRow, 16].Value2 = "Steps";
                    xlNewRange.Cells[startingRow, 17].Value2 = "Actions";
                    xlNewRange.Cells[startingRow, 18].Value2 = "Expected Result";

                }
                //StringBuilder result1 = new StringBuilder(xlNewRange.Cells[startingRow, 6].Value2);
                int count = 0;
                int stepCount = 1;
                xlNewRange.Cells[startingRow, 16].Value2 = stepCount.ToString();
                xlNewRange.Cells[startingRow, 17].Value2 = "Log in to worker portal with Valid Credentials";
                xlNewRange.Cells[startingRow, 18].Value2 = "Log in must be successful";
                int row = startingRow;

                for (int j = 3; j <= colCount; j++)
                {
                    //new line
                    if (j == 3)
                        Console.Write("\r\n");
                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        string permission = xlRange.Cells[1, j].Value2.ToString();
                        string rolePermission = xlRange.Cells[i, 2].Value2.ToString();
                        string value = (xlRange.Cells[i, j].Value2.ToString());
                        listOFPermissions.Add(permission);
                        if (value == "X" && xlRange.Cells[1, j].Value2 != null)
                        {
                            Console.WriteLine("Row number: " + startingRow);
                            stringBuilder.Append(permission).Append(", ").Replace(",  ",".");
                            //Build scenarios here
                            startingRow++;
                            stepCount++;
                            xlNewRange.Cells[startingRow, 16].Value2 = (stepCount).ToString();
                            xlNewRange.Cells[startingRow, 17].Value2 = "Validate that the user has the " + rolePermission + " function with the following permission - " + permission + " with the corresponding field permissions as indicated in the reference document - " + "DMAS NPM Worker Roles";
                            xlNewRange.Cells[startingRow, 18].Value2 = "All " + permission + " fields are behaving as expected baed on Edit and View permissions for this function";
                            xlNewRange.Cells[startingRow, 19].Value2 = "DMAS NPM Worker Roles";

                            count++;
                        }
                    }
                }
                Console.WriteLine("Row where value is input " + row);
                xlNewRange.Cells[row, 6].Value2 = stringBuilder.ToString();

                //string cellValue = xlNewRange.Cells[startingRow, 6].Value2;
                //Console.WriteLine(cellValue);
                totalCount = +count;

            }


            xlNewWorkbook.SaveAs(@"c:\test_SecurityRoles.xlsx");
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlNewWorksheet);
            Marshal.ReleaseComObject(xlNewRange);

            //close and release
            xlWorkbook.Close();
            xlNewWorkbook.Close(true, misValue, misValue);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlNewWorkbook);

            //quit and release
            xlApp.Quit();
            xlNewApp.Quit();
            Marshal.ReleaseComObject(xlNewApp);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}