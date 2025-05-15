#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Diagnostics;
using Syncfusion.Pdf.Interactive;
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf.Grid;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CustomTag : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public CustomTag()
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
        # region Fields
        System.Drawing.Color gray = System.Drawing.Color.FromArgb(255, 77, 77, 77);
        System.Drawing.Color black = System.Drawing.Color.FromArgb(255, 0, 0, 0);
        System.Drawing.Color white = System.Drawing.Color.FromArgb(255, 255, 255, 255);
        System.Drawing.Color violet = System.Drawing.Color.FromArgb(255, 151, 108, 174);
        #endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {




            Font font = new Font("Arial", 9);
            Font title = new Font("Arial", 22);
            Font head = new Font("Arial", 10);
            Font head1 = new Font("Arial", 16);
            PdfFont fontnormal = new PdfTrueTypeFont(font, System.Drawing.FontStyle.Regular, 9, true, true);
            PdfFont fontTitle = new PdfTrueTypeFont(title, System.Drawing.FontStyle.Bold, 22, true, true);
            PdfFont fontHead = new PdfTrueTypeFont(head, System.Drawing.FontStyle.Bold, 10, true, true);
            PdfFont fontHead2 = new PdfTrueTypeFont(head1, System.Drawing.FontStyle.Bold, 16, true, true);


            #region content string
            string pdfChapter = "We’ll begin with a conceptual overview of a simple PDF document. This chapter is designed to be a brief orientation before diving in and creating a real document from scratch \r\n \r\n A PDF file can be divided into four parts: a header, body, cross-reference table, and trailer. The header marks the file as a PDF, the body defines the visible document, the cross-reference table lists the location of everything in the file, and the trailer provides instructions for how to start reading the file.";
            string header = "The header is simply a PDF version number and an arbitrary sequence of binary data.The binary data prevents naïve applications from processing the PDF as a text file. This would result in a corrupted file, since a PDF typically consists of both plain text and binary data (e.g., a binary font file can be directly embedded in a PDF).";
            string body = "The page tree serves as the root of the document. In the simplest case, it is just a list of the pages in the document. Each page is defined as an independent entity with metadata (e.g., page dimensions) and a reference to its resources and content, which are defined separately. Together, the page tree and page objects create the “paper” that composes the document.\r\n \r\n  Resources are objects that are required to render a page. For example, a single font is typically used across several pages, so storing the font information in an external resource is much more efficient. A content object defines the text and graphics that actually show up on the page. Together, content objects and resources define theappearance of an individual page. \r\n \r\n  Finally, the document’s catalog tells applications where to start reading the document. Often, this is just a pointer to the root page tree.";
            string resource = "The third object is a resource defining a font configuration. \r\n \r\n The /Font key contains a whole dictionary, opposed to the name/value pairs we’ve seen previously (e.g., /Type /Page). The font we configured is called /F0, and the font face we selected is /Times-Roman. The /Subtype is the format of the font file, and /Type1 refers to the PostScript type 1 file format. The specification defines 14 “standard” fonts that all PDF applications should support.";
            string crossRef = "After the header and the body comes the cross-reference table. It records the byte location of each object in the body of the file. This enables random-access of the document, so when rendering a page, only the objects required for that page are read from the file. This makes PDFs much faster than their PostScript predecessors, which had to read in the entire file before processing it.";
            string trailer = "Finally, we come to the last component of a PDF document. The trailer tells applications how to start reading the file. At minimum, it contains three things: \r\n 1. A reference to the catalog which links to the root of the document. \r\n 2. The location of the cross-reference table. \r\n 3. The size of the cross-reference table. \r\n \r\n Since a trailer is all you need to begin processing a document, PDFs are typically read back-to-front: first, the end of the file is found, and then you read backwards until you arrive at the beginning of the trailer. After that, you should have all the information you need to load any page in the PDF.";
            #endregion


            //Create a new PDF document.

            PdfDocument document = new PdfDocument();

            document.DocumentInformation.Title = "CustomTag";

            #region page1
            //Add a page to the document.

            PdfPage page1 = document.Pages.Add();

            //Load the image from the disk.

            PdfBitmap image = new PdfBitmap(GetFileStream("CustomTag.jpg"));

            PdfStructureElement imageElement = new PdfStructureElement(PdfTagType.Figure);
            imageElement.AlternateText = "PDF Succintly image";
            //adding tag to the PDF image
            image.PdfTag = imageElement;
            //Draw the image
            page1.Graphics.DrawImage(image, 0, 0, page1.GetClientSize().Width, page1.GetClientSize().Height - 20);

            #endregion


            #region page2

            PdfPage page2 = document.Pages.Add();

            PdfStructureElement hTextElement1 = new PdfStructureElement(PdfTagType.HeadingLevel1);
            PdfStructureElement headingFirstLevel = new PdfStructureElement(PdfTagType.HeadingLevel2);
            PdfStructureElement hTextElementLevel3 = new PdfStructureElement(PdfTagType.HeadingLevel3);
            headingFirstLevel.Parent = hTextElement1;
            hTextElementLevel3.Parent = hTextElement1;
            PdfTextElement headerElement1 = new PdfTextElement("Chapter 1 Conceptual Overview", fontTitle, PdfBrushes.Black);

            headerElement1.PdfTag = headingFirstLevel;
            headerElement1.Draw(page2, new PointF(100, 0));

            //Initialize the structure element with tag type paragraph.

            PdfStructureElement textElement1 = new PdfStructureElement(PdfTagType.Paragraph);
            textElement1.Parent = headingFirstLevel;
            textElement1.ActualText = pdfChapter;

            PdfTextElement element1 = new PdfTextElement(pdfChapter, fontnormal);
            element1.PdfTag = textElement1;
            element1.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element1.Draw(page2, new RectangleF(0, 40, page2.GetClientSize().Width, 70));

            PdfStructureElement hTextElement2 = new PdfStructureElement(PdfTagType.HeadingLevel2);
            hTextElement2.Parent = hTextElement1;
            hTextElement2.ActualText = "Header";

            PdfTextElement headerElement2 = new PdfTextElement("Header", fontHead2, PdfBrushes.Black);
            headerElement2.PdfTag = hTextElement2;
            headerElement2.Draw(page2, new PointF(0, 140));

            PdfStructureElement textElement2 = new PdfStructureElement(PdfTagType.Paragraph);
            textElement2.Parent = hTextElementLevel3;
            textElement2.ActualText = header;

            PdfTextElement element2 = new PdfTextElement(header, fontnormal);
            element2.PdfTag = textElement2;
            element2.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element2.Draw(page2, new RectangleF(0, 170, page2.GetClientSize().Width, 40));


            PdfStructureElement hTextElement3 = new PdfStructureElement(PdfTagType.HeadingLevel2);
            hTextElement3.Parent = hTextElement1;
            hTextElement3.ActualText = "Body";

            PdfTextElement headerElement3 = new PdfTextElement("Body", fontHead2, PdfBrushes.Black);
            headerElement3.PdfTag = hTextElement3;
            headerElement3.Draw(page2, new PointF(0, 210));

            PdfStructureElement textElement3 = new PdfStructureElement(PdfTagType.Paragraph);
            textElement3.Parent = hTextElementLevel3;
            textElement3.ActualText = body;

            PdfTextElement element3 = new PdfTextElement(body, fontnormal);
            element3.PdfTag = textElement3;
            element3.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element3.Draw(page2, new RectangleF(0, 240, page2.GetClientSize().Width, 120));

            PdfStructureElement hTextElement6 = new PdfStructureElement(PdfTagType.HeadingLevel2);
            hTextElement6.Parent = hTextElement1;
            hTextElement6.ActualText = "Cross-Reference Table";

            PdfTextElement headerElement5 = new PdfTextElement("Cross-Reference Table", fontHead2, PdfBrushes.Black);
            headerElement5.PdfTag = hTextElement6;
            headerElement5.Draw(page2, new PointF(0, 380));

            PdfStructureElement textElement6 = new PdfStructureElement(PdfTagType.Paragraph);
            textElement6.Parent = hTextElementLevel3;
            textElement6.ActualText = crossRef;

            PdfTextElement element6 = new PdfTextElement(crossRef, fontnormal);
            element6.PdfTag = textElement6;
            element6.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element6.Draw(page2, new RectangleF(0, 410, page2.GetClientSize().Width, 50));

            PdfStructureElement hTextElement7 = new PdfStructureElement(PdfTagType.HeadingLevel2);
            hTextElement7.Parent = hTextElement1;
            hTextElement7.ActualText = "Trailer";

            PdfTextElement headerElement6 = new PdfTextElement("Trailer", fontHead2, PdfBrushes.Black);
            headerElement6.PdfTag = hTextElement7;
            headerElement6.Draw(page2, new PointF(0, 470));

            PdfStructureElement textElement7 = new PdfStructureElement(PdfTagType.Paragraph);
            textElement7.Parent = hTextElementLevel3;
            textElement7.ActualText = trailer;

            PdfTextElement element7 = new PdfTextElement(trailer, fontnormal);
            element7.PdfTag = textElement7;
            element7.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element7.Draw(page2, new RectangleF(0, 500, page2.GetClientSize().Width, 110));



            #endregion

            #region page3

            PdfPage page3 = document.Pages.Add();

            PdfStructureElement hTextElement4 = new PdfStructureElement(PdfTagType.HeadingLevel2);
            hTextElement4.Parent = hTextElement1;
            hTextElement4.ActualText = "Resource";


            PdfTextElement headerElement4 = new PdfTextElement("Resource", fontHead2, PdfBrushes.Black);
            headerElement4.PdfTag = hTextElement4;
            headerElement4.Draw(page3, new PointF(0, 0));

            PdfStructureElement textElement4 = new PdfStructureElement(PdfTagType.Paragraph);
            textElement4.Parent = hTextElementLevel3;
            textElement4.ActualText = resource;

            PdfTextElement element4 = new PdfTextElement(resource, fontnormal);
            element4.PdfTag = textElement4;
            element4.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element4.Draw(page3, new RectangleF(0, 40, page2.GetClientSize().Width, 70));

            //Create a new PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

            PdfStructureElement element = new PdfStructureElement(PdfTagType.Table);
            
            //Adding tag to PDF grid.
            pdfGrid.PdfTag = element;

            //Add three columns.
            pdfGrid.Columns.Add(3);
            PdfGridRow[] headerRow = pdfGrid.Headers.Add(1);
            PdfGridRow pdfGridHeader = pdfGrid.Headers[0];
            pdfGridHeader.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 13);
            pdfGridHeader.ApplyStyle(headerStyle);

            pdfGridHeader.Cells[0].Value = "Times Roman Family";
            pdfGridHeader.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableHeader) { Scope = ScopeType.Column };

            pdfGridHeader.Cells[1].Value = "Helvetica Family";
            pdfGridHeader.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableHeader) { Scope = ScopeType.Column };
            pdfGridHeader.Cells[2].Value = "Courier Family";
            pdfGridHeader.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableHeader) { Scope = ScopeType.Column };

            PdfGridRow pdfGridRow1 = pdfGrid.Rows.Add();
            pdfGridRow1.PdfTag = new PdfStructureElement(PdfTagType.TableRow);
            
            pdfGridRow1.Cells[0].Value = "Times roman";

            pdfGridRow1.Cells[1].Value = "Helvetica";

            pdfGridRow1.Cells[2].Value = "Courier";

            pdfGridRow1.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow1.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow1.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);


            PdfGridRow pdfGridRow2 = pdfGrid.Rows.Add();
            pdfGridRow2.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

            pdfGridRow2.Cells[0].Value = "Times-Bold";

            pdfGridRow2.Cells[1].Value = "Helvetica-Bold";

            pdfGridRow2.Cells[2].Value = "Courier-Bold";

            pdfGridRow2.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow2.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow2.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            PdfGridRow pdfGridRow3 = pdfGrid.Rows.Add();

            pdfGridRow3.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

            pdfGridRow3.Cells[0].Value = "Times-Italic";

            pdfGridRow3.Cells[1].Value = "Helvetica-Oblique";

            pdfGridRow3.Cells[2].Value = "Courier-Oblique";

            pdfGridRow3.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow3.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow3.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);

            PdfGridRow pdfGridRow4 = pdfGrid.Rows.Add();

            pdfGridRow4.PdfTag = new PdfStructureElement(PdfTagType.TableRow);

            pdfGridRow4.Cells[0].Value = "Times-BoldItalic";

            pdfGridRow4.Cells[1].Value = "Helvetica-BoldOblique";

            pdfGridRow4.Cells[2].Value = "Courier-BoldOblique";

            pdfGridRow4.Cells[0].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow4.Cells[1].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);
            pdfGridRow4.Cells[2].PdfTag = new PdfStructureElement(PdfTagType.TableDataCell);



            pdfGrid.BeginCellLayout += PdfGrid_BeginCellLayout;
            pdfGrid.Draw(page3, new PointF(20, 130));

            PdfStructureElement element8 = new PdfStructureElement(PdfTagType.Figure);
            element8.AlternateText = "Rectangle Sample";
            PdfRectangle rect = new PdfRectangle(20, 120, 490, 90);
            rect.PdfTag = element8;
            rect.Draw(page3.Graphics);



            #endregion

        



            //Save and close the document.
            document.Save("CustomTag.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("CustomTag.pdf") { UseShellExecute = true };
                process.Start();
            }

        }
        private void PdfGrid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
        {
            // setting transparent color pen as table BorderPen. 
            PdfPen transparentPen = new PdfPen(new PdfColor(System.Drawing.Color.FromArgb(System.Drawing.Color.Transparent.A, System.Drawing.Color.Transparent.R, System.Drawing.Color.Transparent.G, System.Drawing.Color.Transparent.B)), .3f);

            PdfGridCellStyle pdfGridCellStyle = new PdfGridCellStyle();
            pdfGridCellStyle.Borders.All = transparentPen;

            args.Style = pdfGridCellStyle;
            args.Style.Font = new PdfTrueTypeFont(new Font("Arial", 8), System.Drawing.FontStyle.Regular, 8, true, true);
            args.Style.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        # endregion
    }
}
