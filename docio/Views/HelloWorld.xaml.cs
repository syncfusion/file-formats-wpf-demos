#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;
using System.Reflection;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class HelloWorld : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public HelloWorld()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //A new document is created.
                using (WordDocument document = new WordDocument())
                {
                    //Adding a new section to the document.
                    WSection section = document.AddSection() as WSection;
                    //Set Margin of the section
                    section.PageSetup.Margins.All = 72;
                    //Set page size of the section
                    section.PageSetup.PageSize = new System.Drawing.SizeF(612, 792);
                    //Create Paragraph styles
                    WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
                    style.CharacterFormat.FontName = "Calibri";
                    style.CharacterFormat.FontSize = 11f;
                    style.ParagraphFormat.BeforeSpacing = 0;
                    style.ParagraphFormat.AfterSpacing = 8;
                    style.ParagraphFormat.LineSpacing = 13.8f;

                    style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
                    style.ApplyBaseStyle("Normal");
                    style.CharacterFormat.FontName = "Calibri Light";
                    style.CharacterFormat.FontSize = 16f;
                    style.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(46, 116, 181);
                    style.ParagraphFormat.BeforeSpacing = 12;
                    style.ParagraphFormat.AfterSpacing = 0;
                    style.ParagraphFormat.Keep = true;
                    style.ParagraphFormat.KeepFollow = true;
                    style.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;
                    IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();

                    WPicture picture = paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream(@"AdventureCycle.jpg"))) as WPicture;
                    picture.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
                    picture.VerticalOrigin = VerticalOrigin.Margin;
                    picture.VerticalPosition = -45;
                    picture.HorizontalOrigin = HorizontalOrigin.Column;
                    picture.HorizontalPosition = 263.5f;
                    picture.WidthScale = 20;
                    picture.HeightScale = 15;

                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                    WTextRange textRange = paragraph.AppendText("Adventure Works Cycles") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Calibri";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Red;

                    //Appends paragraph.
                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Heading 1");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    textRange = paragraph.AppendText("Adventure Works Cycles") as WTextRange;
                    textRange.CharacterFormat.FontSize = 18f;
                    textRange.CharacterFormat.FontName = "Calibri";

                    //Appends paragraph.
                    paragraph = section.AddParagraph();
                    paragraph.ParagraphFormat.FirstLineIndent = 36;
                    paragraph.BreakCharacterFormat.FontSize = 12f;
                    textRange = paragraph.AppendText("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;

                    paragraph = section.AddParagraph();
                    paragraph.ParagraphFormat.FirstLineIndent = 36;
                    paragraph.BreakCharacterFormat.FontSize = 12f;
                    textRange = paragraph.AppendText("In 2000, Adventure Works Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the Adventure Works Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno, became the sole manufacturer and distributor of the touring bicycle product group.") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Heading 1");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                    textRange = paragraph.AppendText("Product Overview") as WTextRange;
                    textRange.CharacterFormat.FontSize = 16f;
                    textRange.CharacterFormat.FontName = "Calibri";
                    //Appends table.
                    IWTable table = section.AddTable();
                    table.ResetCells(3, 2);
                    table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
                    table.TableFormat.IsAutoResized = true;

                    //Appends paragraph.
                    paragraph = table[0, 0].AddParagraph();
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.BreakCharacterFormat.FontSize = 12f;
                    //Appends picture to the paragraph.
                    picture = paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream(@"Mountain-200.jpg"))) as WPicture;
                    picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
                    picture.VerticalOrigin = VerticalOrigin.Paragraph;
                    picture.VerticalPosition = 4.5f;
                    picture.HorizontalOrigin = HorizontalOrigin.Column;
                    picture.HorizontalPosition = -2.15f;
                    picture.WidthScale = 79;
                    picture.HeightScale = 79;

                    //Appends paragraph.
                    paragraph = table[0, 1].AddParagraph();
                    paragraph.ApplyStyle("Heading 1");
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.AppendText("Mountain-200");
                    //Appends paragraph.
                    paragraph = table[0, 1].AddParagraph();
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.BreakCharacterFormat.FontSize = 12f;
                    paragraph.BreakCharacterFormat.FontName = "Times New Roman";

                    textRange = paragraph.AppendText("Product No: BK-M68B-38\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Size: 38\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Weight: 25\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Price: $2,294.99\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    //Appends paragraph.
                    paragraph = table[0, 1].AddParagraph();
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.BreakCharacterFormat.FontSize = 12f;

                    //Appends paragraph.
                    paragraph = table[1, 0].AddParagraph();
                    paragraph.ApplyStyle("Heading 1");
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.AppendText("Mountain-300 ");
                    //Appends paragraph.
                    paragraph = table[1, 0].AddParagraph();
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.BreakCharacterFormat.FontSize = 12f;
                    paragraph.BreakCharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Product No: BK-M47B-38\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Size: 35\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Weight: 22\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Price: $1,079.99\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    //Appends paragraph.
                    paragraph = table[1, 0].AddParagraph();
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.BreakCharacterFormat.FontSize = 12f;

                    //Appends paragraph.
                    paragraph = table[1, 1].AddParagraph();
                    paragraph.ApplyStyle("Heading 1");
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    //Appends picture to the paragraph.
                    picture = paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream(@"Mountain-300.jpg"))) as WPicture;
                    picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
                    picture.VerticalOrigin = VerticalOrigin.Paragraph;
                    picture.VerticalPosition = 8.2f;
                    picture.HorizontalOrigin = HorizontalOrigin.Column;
                    picture.HorizontalPosition = -14.95f;
                    picture.WidthScale = 75;
                    picture.HeightScale = 75;

                    //Appends paragraph.
                    paragraph = table[2, 0].AddParagraph();
                    paragraph.ApplyStyle("Heading 1");
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    //Appends picture to the paragraph.
                    picture = paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream(@"Road-550-W.jpg"))) as WPicture;
                    picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
                    picture.VerticalOrigin = VerticalOrigin.Paragraph;
                    picture.VerticalPosition = 3.75f;
                    picture.HorizontalOrigin = HorizontalOrigin.Column;
                    picture.HorizontalPosition = -5f;
                    picture.WidthScale = 92;
                    picture.HeightScale = 92;

                    //Appends paragraph.
                    paragraph = table[2, 1].AddParagraph();
                    paragraph.ApplyStyle("Heading 1");
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.AppendText("Road-150 ");
                    //Appends paragraph.
                    paragraph = table[2, 1].AddParagraph();
                    paragraph.ParagraphFormat.AfterSpacing = 0;
                    paragraph.ParagraphFormat.LineSpacing = 12f;
                    paragraph.BreakCharacterFormat.FontSize = 12f;
                    paragraph.BreakCharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Product No: BK-R93R-44\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Size: 44\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Weight: 14\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    textRange = paragraph.AppendText("Price: $3,578.27\r") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    //Appends paragraph.
                    section.AddParagraph();

                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Hello World.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Hello World.doc") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Win32Exception ex)
                                {
                                    MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Hello World.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as docx format
                    else if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Hello World.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Hello World.docx") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Win32Exception ex)
                                {
                                    MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Hello World.docx" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as pdf format
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            ////Convert word document into PDF document
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            ////Save the pdf file
                            pdfDoc.Save("Hello World.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Hello World.pdf") { UseShellExecute = true };
                                    process.Start();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("PDF Viewer is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Hello World.pdf" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Get the file as stream from assets
        /// </summary>
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(HelloWorld).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.dociodemos.wpf.Assets.DocIO." + fileName);
        }

        # endregion
    }
}