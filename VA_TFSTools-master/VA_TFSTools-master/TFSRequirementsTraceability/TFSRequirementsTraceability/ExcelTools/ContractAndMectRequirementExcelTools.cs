using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Data.Mappings;
using Excel = Microsoft.Office.Interop.Excel;

namespace RequirementsTraceability.ExcelTools
{
    public class ContractAndMectRequirementExcelTools : IDisposable
    {
        private string _fileName;
        private string _saveLocation;
        private string _executionSheetName;
        private string _scriptSheetName;

        private Excel.Application _xlApp = new Excel.Application();
        private Excel.Workbook _xlWorkbook;
        private Excel.Worksheet _opssWorksheet;
        private Excel.Worksheet _plmsWorksheet;

        private Excel.Worksheet _crpWorksheet;
        private Excel.Worksheet _playbookWorksheet;
        private Excel.Worksheet _productDsdWorksheet;

        private Dictionary<string, int> _crpSessionMapping;
        private Dictionary<string, int> _playbookMapping;
        private Dictionary<string, int> _productDsdMapping;
        public ContractAndMectRequirementExcelTools(Properties props)
        {
            _fileName = props.FileName;
            _saveLocation = props.SaveLocation;
            _executionSheetName = props.ExecutionSheetName;
            _scriptSheetName = props.ScriptSheetName;

            try
            {
                _xlWorkbook = _xlApp.Workbooks.Open(_saveLocation + _fileName);
                Console.WriteLine("Excel file is opened.");
            }
            catch
            {
                Console.Write("File Location/Name is not valid. Please press Enter and run the program again.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            _opssWorksheet = _xlWorkbook.Worksheets["OPSS"];
            _plmsWorksheet = _xlWorkbook.Worksheets["PLMS"];

            _crpWorksheet = _xlWorkbook.Worksheets["CRP Sessions"];
            _playbookWorksheet = _xlWorkbook.Worksheets["Playbooks"];
            _productDsdWorksheet = _xlWorkbook.Worksheets["Product DSD"];

            _crpSessionMapping = GenerateWorksheetMapping(_crpWorksheet);
            _playbookMapping = GenerateWorksheetMapping(_playbookWorksheet);
            _productDsdMapping = GenerateWorksheetMapping(_productDsdWorksheet);
        }

        public List<ContractRequirementMectRequirementMap> GatherContractRequirementMectMapping()
        {
            List<ContractRequirementMectRequirementMap> res = new List<ContractRequirementMectRequirementMap>();

            int usedOpssRows = GetUsedRows(_opssWorksheet);
            int usedPlmsRows = GetUsedRows(_plmsWorksheet);

            using (var progress = new ProgressBar())
            {
                double totalCount = usedOpssRows + usedPlmsRows - 8;
                double currCount = 1;
                for (int i = 3; i <= usedOpssRows; i++)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);
                    if (_opssWorksheet.Cells[i, 2].Text != "")
                    {
                        ContractRequirementMectRequirementMap currMap = new ContractRequirementMectRequirementMap();
                        //Console.WriteLine(_opssWorksheet.Cells[i, 5].ToString());
                        currMap.ParentContractRequirementId = Convert.ToInt32(_opssWorksheet.Cells[i, 5].Text);
                        currMap.ChildContractRequirementId = Convert.ToInt32(_opssWorksheet.Cells[i, 2].Text);

                        res.Add(currMap);
                    }
                }

                for (int i = 3; i < usedPlmsRows; i++)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);
                    if (_plmsWorksheet.Cells[i, 2].Text != "")
                    {
                        ContractRequirementMectRequirementMap currMap = new ContractRequirementMectRequirementMap();
                        currMap.ParentContractRequirementId = Convert.ToInt32(_plmsWorksheet.Cells[i, 5].Text);
                        currMap.ChildContractRequirementId = Convert.ToInt32(_plmsWorksheet.Cells[i, 2].Text);

                        res.Add(currMap);
                    }
                }
            }

            return res;
        }

        public List<ContractRequirement> GatherContractRequirements()
        {
            List<ContractRequirement> res = new List<ContractRequirement>();

            res.AddRange(GatherRequirements(_opssWorksheet));
            res.AddRange(GatherRequirements(_plmsWorksheet));

            return res;
        }

        private List<ContractRequirement> GatherRequirements(Excel.Worksheet worksheet)
        {
            List<ContractRequirement> res = new List<ContractRequirement>();

            int usedRows = GetUsedRows(worksheet);

            List<int> existingRequirements = new List<int>();

            using (var progress = new ProgressBar())
            {
                Console.Write("Gathering Requirements... ");
                for (int i = 3; i <= usedRows; i++)
                {
                    progress.Report((double)i / (double)usedRows);
                    if (!existingRequirements.Contains(Convert.ToInt32(worksheet.Cells[i, 5].Value2.ToString())))
                    {
                        ContractRequirement currContractRequirement = new ContractRequirement();

                        currContractRequirement.RequirementID = Convert.ToInt32(worksheet.Cells[i, 5].Value2.ToString());
                        currContractRequirement.RequirementTitle = worksheet.Cells[i, 6].Value2.ToString();
                        currContractRequirement.Description = worksheet.Cells[i, 7].Value2.ToString();
                        currContractRequirement.ProposedLanguage = worksheet.Cells[i, 8].Value2.ToString();
                        currContractRequirement.PrimaryArea = worksheet.Cells[i, 9].Value2.ToString();
                        currContractRequirement.State = worksheet.Cells[i, 10].Value2.ToString();
                        currContractRequirement.Validated = worksheet.Cells[i, 11].Value2.ToString();
                        if (worksheet.Cells[i, 12].Value2 != null)
                        {
                            currContractRequirement.DeScopeDetails = worksheet.Cells[i, 12].Value2.ToString();
                        }
                        if (worksheet.Cells[i, 13].Value2 != null)
                        {
                            currContractRequirement.ValidationActionItem = worksheet.Cells[i, 13].Value2.ToString();
                        }
                        if (worksheet.Cells[i, 14].Value2 != null)
                        {
                            currContractRequirement.ValidationActionItemStatus = worksheet.Cells[i, 14].Value2.ToString();
                        }
                        if (worksheet.Cells[i, 15].Value2 != null)
                        {
                            currContractRequirement.ValidationAssumptions = worksheet.Cells[i, 15].Value2.ToString();
                        }
                        if (worksheet.Cells[i, 16].Value2 != null)
                        {
                            currContractRequirement.Deliverable = worksheet.Cells[i, 16].Value2.ToString();
                        }
                        if (worksheet.Cells[i, 17].Value2 != null)
                        {
                            currContractRequirement.CoveredInCrp = worksheet.Cells[i, 17].Value2.ToString();
                        }
                        if (worksheet.Cells[i, 18].Value2 != null)
                        {
                            List<string> allCrpSession = ExtractNewLineValues(worksheet.Cells[i, 18].Value2.ToString());
                            currContractRequirement.CrpSession = new List<CrpSession>();

                            foreach (string crpSession in allCrpSession)
                            {
                                if (_crpSessionMapping.ContainsKey(crpSession))
                                {
                                    CrpSession currCrpSession = new CrpSession
                                    {
                                        CrpSessionId = _crpSessionMapping[crpSession],
                                        CrpSessionName = crpSession
                                    };
                                    currContractRequirement.CrpSession.Add(currCrpSession);
                                }
                            }
                        }

                        if (worksheet.Cells[i, 19].Value2 != null)
                        {
                            currContractRequirement.SolutionUnderstanding = worksheet.Cells[i, 19].Value2.ToString();
                        }

                        if (worksheet.Cells[i, 20].Value2 != null)
                        {
                            //Console.WriteLine(_opssWorksheet.Cells[i, 20].Value2);
                            List<string> allPlaybooks = ExtractNewLineValues(worksheet.Cells[i, 20].Value2.ToString());
                            currContractRequirement.Playbooks = new List<Playbook>();

                            foreach (string playbook in allPlaybooks)
                            {
                                if (_playbookMapping.ContainsKey(playbook))
                                {
                                    Playbook currPlaybook = new Playbook
                                    {
                                        PlaybookId = _playbookMapping[playbook],
                                        PlaybookName = playbook
                                    };
                                    currContractRequirement.Playbooks.Add(currPlaybook);
                                }
                            }
                        }

                        if (worksheet.Cells[i, 21].Value2 != null)
                        {
                            List<string> allWorkPackages = ExtractNewLineValues(worksheet.Cells[i, 21].Value2.ToString());
                            currContractRequirement.WorkPackages = new List<WorkPackage>();

                            foreach (string workPackage in allWorkPackages)
                            {
                                WorkPackage currWorkPackage = new WorkPackage
                                {
                                    WorkPackageName = workPackage
                                };
                                currContractRequirement.WorkPackages.Add(currWorkPackage);
                            }
                        }

                        if (worksheet.Cells[i, 22].Value2 != null)
                        {
                            List<string> allProductDsd = ExtractNewLineValues(worksheet.Cells[i, 22].Value2.ToString());
                            currContractRequirement.ProductDSD = new List<ProductDsd>();

                            foreach (string productDsd in allProductDsd)
                            {
                                if (_productDsdMapping.ContainsKey(productDsd))
                                {
                                    ProductDsd currProductDsd = new ProductDsd
                                    {
                                        ProductDsdId = _productDsdMapping[productDsd],
                                        ProductDsdName = productDsd
                                    };
                                    currContractRequirement.ProductDSD.Add(currProductDsd);
                                }
                            }
                        }

                        if (worksheet.Cells[i, 24].Value2 != null)
                        {
                            currContractRequirement.VendorIntegration = worksheet.Cells[i, 24].Value2.ToString();
                        }

                        if (worksheet.Cells[i, 25].Value2 != null)
                        {
                            currContractRequirement.Coverage = worksheet.Cells[i, 25].Value2.ToString();
                        }

                        existingRequirements.Add(currContractRequirement.RequirementID);
                        res.Add(currContractRequirement);
                    }
                }
                Console.WriteLine();
            }

            return res;
        }

        public void UpdateMectAndContractRequirementIds(List<ContractRequirement> contractRequirements, List<MectRequirement> mectRequirements)
        {
            //Dictionary<string, List<int>> contractRequirementOPSSMapping = GetContractRequirementNamesMapping(_opssWorksheet);
            //Dictionary<string, List<int>> mectRequirementOPSSMapping = GetMectNamesMapping(_opssWorksheet);

            //using (var progress = new ProgressBar())
            //{
            //    Console.WriteLine("Writing Contract Requirement IDs... ");
            //    double totalCount = contractRequirements.Count;

            //    double currCount = 1; 
            //    foreach (ContractRequirement currContractRequirement in contractRequirements)
            //    {
            //        currCount += 1;
            //        progress.Report(currCount / totalCount);
            //        if (contractRequirementOPSSMapping.ContainsKey(currContractRequirement.RequirementTitle))
            //        {
            //            foreach (int rows in contractRequirementOPSSMapping[currContractRequirement.RequirementTitle])
            //            {
            //                _opssWorksheet.Cells[rows, 5] = currContractRequirement.RequirementID;
            //            }
            //        }
            //    }
            //}

            //using (var progress = new ProgressBar())
            //{
            //    Console.WriteLine("Writing MECT Requirement IDs... ");
            //    double totalCount = mectRequirements.Count;

            //    double currCount = 1;

            //    foreach (MectRequirement currMectRequirement in mectRequirements)
            //    {
            //        currCount += 1;
            //        progress.Report(currCount / totalCount);
            //        if (mectRequirementOPSSMapping.ContainsKey(currMectRequirement.MectName))
            //        {
            //            foreach (int rows in mectRequirementOPSSMapping[currMectRequirement.MectName])
            //            {
            //                _opssWorksheet.Cells[rows, 2] = currMectRequirement.MectRequirementId;
            //            }
            //        }
            //    }
            //}

            Dictionary<string, List<int>> contractRequirementPLMSMapping = GetContractRequirementNamesMapping(_plmsWorksheet);
            Dictionary<string, List<int>> mectRequirementPLMSMapping = GetMectNamesMapping(_plmsWorksheet);

            using (var progress = new ProgressBar())
            {
                Console.WriteLine("Writing Contract Requirement IDs... ");
                double totalCount = contractRequirements.Count;

                double currCount = 1;
                foreach (ContractRequirement currContractRequirement in contractRequirements)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);
                    if (contractRequirementPLMSMapping.ContainsKey(currContractRequirement.RequirementTitle))
                    {
                        foreach (int rows in contractRequirementPLMSMapping[currContractRequirement.RequirementTitle])
                        {
                            _plmsWorksheet.Cells[rows, 5] = currContractRequirement.RequirementID;
                        }
                    }
                }
            }

            using (var progress = new ProgressBar())
            {
                Console.WriteLine("Writing MECT Requirement IDs... ");
                double totalCount = mectRequirements.Count;

                double currCount = 1;

                foreach (MectRequirement currMectRequirement in mectRequirements)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);
                    if (mectRequirementPLMSMapping.ContainsKey(currMectRequirement.MectName))
                    {
                        foreach (int rows in mectRequirementPLMSMapping[currMectRequirement.MectName])
                        {
                            _plmsWorksheet.Cells[rows, 2] = currMectRequirement.MectRequirementId;
                        }
                    }
                }
            }

            _xlWorkbook.Save();
        }

        private Dictionary<string, List<int>> GetMectNamesMapping(Excel.Worksheet worksheet)
        {
            Dictionary<string, List<int>> mapping = new Dictionary<string, List<int>>();

            int usedRows = GetUsedRows(worksheet);

            Console.WriteLine("Gathering MECT Row Mapping....");
            using (var progress = new ProgressBar())
            {
                for (int i = 3; i <= usedRows; i++)
                {
                    progress.Report((double)i / (double)usedRows);
                    if (worksheet.Cells[i, 3] != null && worksheet.Cells[i, 3].Value2 != "")
                    {
                        string currentName = worksheet.Cells[i, 3].Text;
                        if (!mapping.ContainsKey(currentName))
                        {
                            mapping[currentName] = new List<int> { i };
                        }
                        else
                        {
                            mapping[currentName].Add(i);
                        }
                    }
                }
            }
            Console.WriteLine("Finished MECT Row Mapping...");

            return mapping;
        }

        private Dictionary<string, List<int>> GetContractRequirementNamesMapping(Excel.Worksheet worksheet)
        {
            Dictionary<string, List<int>> mapping = new Dictionary<string, List<int>>();

            int usedRows = GetUsedRows(worksheet);

            Console.WriteLine("Gathering Contract Requirement Mapping....");
            using (var progress = new ProgressBar())
            {
                for (int i = 3; i < usedRows; i++)
                {
                    progress.Report((double)i / (double)usedRows);
                    string currentName = worksheet.Cells[i, 6].Text;
                    if (!mapping.ContainsKey(currentName))
                    {
                        mapping[currentName] = new List<int> { i };
                    }
                    else
                    {
                        mapping[currentName].Add(i);
                    }
                }
            }
            Console.WriteLine("Finished gathering Contract Requirement Mapping...");

            return mapping;
        }

        private Dictionary<string, int> GenerateWorksheetMapping(Excel.Worksheet currWorksheet)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            int usedRows = GetUsedRows(currWorksheet, 1);

            for (int i = 2; i <= usedRows; i++)
            {
                res[currWorksheet.Cells[i, 2].Value2] = Convert.ToInt32(currWorksheet.Cells[i, 1].Value2);
            }

            return res;
        }

        private List<string> ExtractNewLineValues(string val)
        {
            List<string> res = new List<string>();

            res = Regex.Split(val, "\n")
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList<string>();

            return res;
        }

        private int GetUsedRows(Excel.Worksheet worksheet, int column = 6)
        {
            int count = 3;
            while (worksheet.Cells[count, column] != null && worksheet.Cells[count, column].Text != "")
            {
                count += 1;
                //Console.WriteLine(count);
            }

            return count - 1;
        }

        public void ExcelCleanup()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(_opssWorksheet);
            Marshal.ReleaseComObject(_plmsWorksheet);

            //close and release
            _xlWorkbook.Close();
            Marshal.ReleaseComObject(_xlWorkbook);

            //quit and release
            _xlApp.Quit();
            Marshal.ReleaseComObject(_xlApp);

            Console.WriteLine("File has been closed and cleaned up.");
        }

        public void Dispose()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(_opssWorksheet);
            Marshal.ReleaseComObject(_plmsWorksheet);

            //close and release
            _xlWorkbook.Close();
            Marshal.ReleaseComObject(_xlWorkbook);

            //quit and release
            _xlApp.Quit();
            Marshal.ReleaseComObject(_xlApp);

            Console.WriteLine("File has been closed and cleaned up.");
        }
    }


}
