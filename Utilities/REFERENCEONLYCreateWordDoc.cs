
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Xceed.Words.NET;

using Xceed.Words.NET;

namespace NUnit.Tests1.Utilities
{
    public class REFERENCEONLYCreateWordDoc
    {
        //public void CreateDocument()
        //{
        //    try
        //    {
        //        //Create an instance for word app  
        //        Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

        //        //Set animation status for word application  
        //        winword.ShowAnimation = false;

        //        //Set status for word application is to be visible or not.  
        //        winword.Visible = false;

        //        //Create a missing variable for missing value  
        //        object missing = System.Reflection.Missing.Value;

        //        //Create a new document  
        //        Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

        //        //Add header into the document  
        //        foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
        //        {
        //            //Get the header range and add the header details.  
        //            Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //            headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
        //            headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //            headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
        //            headerRange.Font.Size = 10;
        //            headerRange.Text = "Header text goes here";
        //        }

        //        //Add the footers into the document  
        //        foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
        //        {
        //            //Get the footer range and add the footer details.  
        //            Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //            footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
        //            footerRange.Font.Size = 10;
        //            footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //            footerRange.Text = "Footer text goes here";
        //        }

        //        //adding text to document  
        //        document.Content.SetRange(0, 0);
        //        document.Content.Text = "This is test document " + Environment.NewLine;

        //        //Add paragraph with Heading 1 style  
        //        Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
        //        object styleHeading1 = "Heading 1";
        //        para1.Range.set_Style(ref styleHeading1);
        //        para1.Range.Text = "Para 1 text";
        //        para1.Range.InsertParagraphAfter();

        //        //Add paragraph with Heading 2 style  
        //        Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
        //        object styleHeading2 = "Heading 2";
        //        para2.Range.set_Style(ref styleHeading2);
        //        para2.Range.Text = "Para 2 text";
        //        para2.Range.InsertParagraphAfter();

        //        //Create a 5X5 table and insert some dummy record  
        //        Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

        //        firstTable.Borders.Enable = 1;
        //        foreach (Row row in firstTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Header row  
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //other format properties goes here  
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 10;
        //                    //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                              
        //                    cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Center alignment for the Header cells  
        //                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

        //                }
        //                //Data row  
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }

        //        //Save the document  
        //        object filename = @"c:\temp1.docx";
        //        document.SaveAs2(ref filename);
        //        document.Close(ref missing, ref missing, ref missing);
        //        document = null;
        //        winword.Quit(ref missing, ref missing, ref missing);
        //        winword = null;
        //        MessageBox.Show("Document created successfully !");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public void CreateDocument2()
        {
            #region one
            string fileName = "exempleWord.docx";
            var doc = DocX.Create(fileName);
            #endregion
            //doc.MarginLeft = 1;
            //doc.MarginRight = 1;
            //doc.MarginTop = 1;
            //doc.MarginBottom = 1/2;
            //#region two
            ////Formatting Title  
            //string title = "Who is Virat Kohli?";

            ////Formatting Title  
            //// like using this we can set font family, font size, position, font color etc

            //Formatting titleFormat = new Formatting();
            ////Specify font family  
            //titleFormat.FontFamily = new Xceed.Words.NET.Font("Times new roman");
            ////Specify font size  
            //titleFormat.Size = 20D;
            //titleFormat.Position = 40;
            //titleFormat.FontColor = Color.BlueViolet;
            //titleFormat.UnderlineColor = Color.Gray;
            //titleFormat.Italic = true;

            ////Text  
            //string textParagraph = "Dear Friends, " + Environment.NewLine +
            //    "Virat Kohli - (born 5 November 1988) is an Indian international cricketer who currently captains the India national team. A right-handed batsman, often regarded as one of the best batsmen in the world. He plays for the Royal Challengers Bangalore in the Indian Premier League (IPL), & has been the team's captain since 2013.";

            ////Formatting Text Paragraph  
            //Formatting textParagraphFormat = new Formatting();
            ////font family  
            //textParagraphFormat.FontFamily = new Xceed.Words.NET.Font("Century Gothic");
            ////font size  
            //textParagraphFormat.Size = 12D;
            ////Spaces between characters  
            //textParagraphFormat.Spacing = 2;
            ////Insert title  
            //Xceed.Words.NET.Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            //paragraphTitle.Alignment = Alignment.center;
            ////Insert text  
            //doc.InsertParagraph(textParagraph, false, textParagraphFormat);
            //#endregion



            #region TestObjective

            doc.InsertParagraph("Test Objective");
            //Create Table with 2 rows and 4 columns.  
            Table t = doc.AddTable(2, 3);
           // t.Alignment = Alignment.center;
            //t.Design = TableDesign.ColorfulList;
            //t.Design = TableDesign.ColorfulGridAccent1; 
            // Fill cells by adding text.  
            // First row

            //Test Objective table
            string scenarioNumber = "15256";

            string title = "TC_IT03_Member Portal_Submit Invalid data_EIV";
            string testOjective = "What: Verify that the system has the ability to display error messsage to the user when the user submits invalid data in the EIV form.Why: To ensure system can handle the invalid data submitted on the EIV form.";


            t.Rows[0].Cells[0].Paragraphs.First().Append("#");
            t.Rows[0].Cells[1].Paragraphs.First().Append("Title");
            t.Rows[0].Cells[2].Paragraphs.First().Append("Test Objective");

            // Second row details
            t.Rows[1].Cells[0].Paragraphs.First().Append(scenarioNumber);
            t.Rows[1].Cells[1].Paragraphs.First().Append(title);
            t.Rows[1].Cells[2].Paragraphs.First().Append(testOjective);
            doc.InsertTable(t);
            #endregion

            #region Steps To Follow
            doc.InsertParagraph("Steps to Follow");
            //Create Table with 2 rows and 4 columns.  
            int Rows = 5;
            int Column = 3;
            Table stepsToFollow = doc.AddTable(Rows, Column);
            t.Alignment = Alignment.center;
            //t.Design = TableDesign.ColorfulList;
            //t.Design = TableDesign.ColorfulGridAccent1; 
            // Fill cells by adding text.

            // First row

            //Test Objective table
            string steps = "1";

            string action = "Verify that the preconditions are met";
            string expectedResult = "Member should have valid credentials to login to member portal.";

            stepsToFollow.Rows[0].Cells[0].Paragraphs.First().Append("Steps");
            stepsToFollow.Rows[0].Cells[1].Paragraphs.First().Append("Actions");
            t.Rows[0].Cells[2].Paragraphs.First().Append("Expected Result");

            // Second row details
            stepsToFollow.Rows[1].Cells[0].Paragraphs.First().Append(steps);
            stepsToFollow.Rows[1].Cells[1].Paragraphs.First().Append(action);
            stepsToFollow.Rows[1].Cells[2].Paragraphs.First().Append(expectedResult);
            doc.InsertTable(stepsToFollow);
            #endregion


            #region three
            //Create a picture  
            Xceed.Words.NET.Image img = doc.AddImage(@"C:/Users/bryar.h.cole/Desktop/AutomationProvjects/NUnit.Tests1/Reports/HippSearch/images/ApplicationSearchPageSucess1.png");
            Picture p = img.CreatePicture();
            //Create a new paragraph  
            Paragraph par = doc.InsertParagraph("HIPP Application Search Page");

            p.HeightInches = 3.8;
            p.WidthInches = 8.5;
            par.AppendPicture(p);
            par.Alignment = Alignment.center;

            #endregion
            #region five
            // Hyperlink
            Xceed.Words.NET.Hyperlink url = doc.AddHyperlink("Ankpro home page", new Uri("http://www.ankpro.com"));
            Paragraph p1 = doc.InsertParagraph();
            p1.AppendLine("Please visit ").Bold().AppendHyperlink(url).Color(Color.Blue); // Hyperlink in blue color 
            #endregion

            #region part of one
            doc.Save();
            Process.Start("WINWORD.EXE", fileName);
            #endregion
            MessageBox.Show("The Width of the image is " + p.Width  + "\nThe Height is " + p.Height); 

        }
    }
}
