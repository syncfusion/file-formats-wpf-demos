#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Functions;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GraphicBrushes : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public GraphicBrushes()
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
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.PageSettings = new PdfPageSettings(new SizeF(300, 400));

            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfImage image = PdfImage.FromStream(GetFileStream("simple.jpg"));
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 8f, PdfFontStyle.Bold);
            PdfBrush textBrush = PdfBrushes.Black;
            graphics.DrawString("PDF Graphic Brushes", font, textBrush, new PointF(75, 20));
            # region SolidBrush
            graphics.DrawString("Solid Brush", font, textBrush, new PointF(85, 33));
            // Draw ellipse with solid brush.
            RectangleF rectangle = new RectangleF(20, 46, 50, 50);
            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);

            graphics.DrawEllipse(brush, rectangle);

            graphics.TranslateTransform(60, 0);
            brush = new PdfSolidBrush(System.Drawing.Color.Green);
            graphics.DrawEllipse(brush, rectangle);

            graphics.TranslateTransform(60, 0);
            brush.Color = System.Drawing.Color.Red;
            graphics.DrawEllipse(brush, rectangle);
            #endregion

            #region TilingBrush

            // Draw ellipse with tiling brush.
            graphics.TranslateTransform(-120, 65);
            graphics.DrawString("Tiling Brush", font, textBrush, new PointF(85, 33));

            PdfTilingBrush tilingBrush = new PdfTilingBrush(new SizeF(10, 10));
            RectangleF rect = new RectangleF(0, 0, 10, 10);

            // Draw image on to the tiling brush.
            tilingBrush.Graphics.DrawImage(image, rect);

            // Draw ellipse using tiling brush.
            graphics.DrawEllipse(tilingBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            tilingBrush = new PdfTilingBrush(rect);
            // Draw shapes inside tiling brush.
            tilingBrush.Graphics.DrawEllipse(PdfPens.Yellow, rect);
            tilingBrush.Graphics.DrawLine(PdfPens.Green, 0, 0, 10, 10);
            tilingBrush.Graphics.DrawLine(PdfPens.Red, 0, 10, 10, 0);
            graphics.DrawEllipse(tilingBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            rect = new RectangleF(0, 0, 20, 20);
            PdfTilingBrush tilingBrushNew = new PdfTilingBrush(rect);
            tilingBrushNew.Graphics.DrawEllipse(tilingBrush, rect);
            graphics.DrawEllipse(tilingBrushNew, rectangle);
            # endregion

            # region HatchBrush
            // Draw ellipse with hatch brush.
            graphics.TranslateTransform(-120, 65);
            graphics.DrawString("Hatch Brush", font, textBrush, new PointF(85, 33));
            System.Drawing.Color systemForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 0);
            System.Drawing.Color systemBackColor = System.Drawing.Color.FromArgb(255, 78, 167, 46);
            PdfHatchBrush hatchBrush = new PdfHatchBrush(PdfHatchStyle.Cross, new PdfColor(systemForeColor), new PdfColor(systemBackColor));

            graphics.DrawEllipse(PdfPens.Black, hatchBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            systemForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
            systemBackColor = System.Drawing.Color.FromArgb(255, 78, 0, 46);
            hatchBrush = new PdfHatchBrush(PdfHatchStyle.DarkDownwardDiagonal, new PdfColor(systemForeColor), new PdfColor(systemBackColor)); graphics.DrawEllipse(brush, rectangle);
            graphics.DrawEllipse(PdfPens.Black, hatchBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            systemForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 255);
            systemBackColor = System.Drawing.Color.FromArgb(255, 78, 100, 46);
            hatchBrush = new PdfHatchBrush(PdfHatchStyle.SolidDiamond, new PdfColor(systemForeColor), new PdfColor(systemBackColor));
            graphics.DrawEllipse(PdfPens.Black, hatchBrush, rectangle);
            #endregion


            # region LinearGradientBrush
            // Draw ellipse with linear gradient brush.
            graphics.TranslateTransform(-120, 65);
            graphics.DrawString("Linear Gradient Brush", font, textBrush, new PointF(70, 33));
            PdfColor color1 = System.Drawing.Color.Red;
            PdfColor color2 = System.Drawing.Color.Yellow;

            // Create a new linear gradient brush.
            PdfGradientBrush gradientBrush = new PdfLinearGradientBrush(rectangle.Location, (PointF)rectangle.Size, color1, color2);

            // Format before draw.
            gradientBrush.AntiAlias = false;
            gradientBrush.Background = System.Drawing.Color.Green;
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            color2 = System.Drawing.Color.Green;
            gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, 30f);
            gradientBrush.AntiAlias = true;
            graphics.DrawEllipse(gradientBrush, rectangle);

            graphics.TranslateTransform(60, 0);
            color1 = System.Drawing.Color.Yellow;
            gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, PdfLinearGradientMode.ForwardDiagonal);
            graphics.DrawEllipse(gradientBrush, rectangle);

            # endregion

            #region RadialGradientBrush
            // Draw ellipse with radial gradient brush.
            graphics.TranslateTransform(-120, 65);
            graphics.DrawString("Radial Gradient Brush", font, textBrush, new PointF(70, 33));
            color1 = System.Drawing.Color.Red;
            color2 = System.Drawing.Color.Yellow;

            PointF point = new PointF(25, 25);

            // Create a new radial gradient brush.
            gradientBrush = new PdfRadialGradientBrush(point, 50f, point, 5f, color1, color2);

            // Format before draw.
            gradientBrush.AntiAlias = false;
            gradientBrush.Background = System.Drawing.Color.Green;
            graphics.DrawEllipse(gradientBrush, rectangle);
            #endregion

            graphics.TranslateTransform(0, -180f);
            PdfBrush onlyBrush = new PdfSolidBrush(System.Drawing.Color.Black);
            graphics.DrawString("PDF Brushes", font, onlyBrush, new PointF(200, 10));

            Type type = typeof(PdfBrushes);
            object[] parameters = null;
            System.Reflection.PropertyInfo[] properties = type.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                onlyBrush = (PdfSolidBrush)properties[i].GetValue(null, parameters);
                graphics.DrawRectangle(onlyBrush, new RectangleF(200, 30, 50, 2));
                graphics.TranslateTransform(0, 2);
            }

            # region PdfColorSpace

            page = document.Pages.Add();
            PdfGraphics g = page.Graphics;
            g.DrawString("Color Spaces", font, textBrush, new PointF(100, 15));

            //Set DeviceRGB Colorspace.
            document.ColorSpace = PdfColorSpace.RGB;
            page.Graphics.DrawString("Device RGB", font, textBrush, new PointF(20, 30));
            PdfBrush brush1 = PdfBrushes.Green;
            g.DrawRectangle(brush1, new RectangleF(30, 45, 30, 30));

            //Set DeviceCMYK Colorspace.
            document.ColorSpace = PdfColorSpace.CMYK;
            page.Graphics.DrawString("Device CMYK", font, textBrush, new PointF(100, 30));
            g.DrawEllipse(brush1, new RectangleF(110, 45, 30, 30));

            //Set DeviceGray Colorspace.
            document.ColorSpace = PdfColorSpace.GrayScale;
            page.Graphics.DrawString("Device Gray", font, textBrush, new PointF(180, 30));
            g.DrawPie(brush1, new RectangleF(190, 45, 30, 30), 0, 45);
            # endregion

            # region CIE Based Color Space

            # region CalRGB Color
            document.ColorSpace = PdfColorSpace.RGB;
            g.DrawString("CalRGB Color", font, textBrush, new PointF(20, 82));

            rect = new RectangleF(30, 97, 30, 30);

            // Instantiate CalRGB Color Space
            PdfCalRGBColorSpace calRgbCS = new PdfCalRGBColorSpace();
            calRgbCS.Gamma = new double[] { 1.6, 1.1, 2.5 };
            calRgbCS.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            calRgbCS.WhitePoint = new double[] { 0.2, 1, 0.8 };
            PdfCalRGBColor red = new PdfCalRGBColor(calRgbCS);
            red.Red = 0;
            red.Green = 1;
            red.Blue = 0;

            PdfBrush brush2 = new PdfSolidBrush(red);
            g.DrawRectangle(brush2, rect);
            #endregion

            #region CalGray Color
            g.DrawString("CalGray Color", font, textBrush, new PointF(100, 82));
            rect = new RectangleF(110, 97, 30, 30);

            PdfCalGrayColorSpace calGrayCS = new PdfCalGrayColorSpace();
            calGrayCS.Gamma = 0.7;
            calGrayCS.WhitePoint = new double[] { 0.2, 1, 0.8 };

            PdfCalGrayColor red1 = new PdfCalGrayColor(calGrayCS);
            red1.Gray = 0.1;
            brush2 = new PdfSolidBrush(red1);
            g.DrawRectangle(brush2, rect);
            #endregion

            #region Lab Color
            g.DrawString("Lab Color", font, textBrush, new PointF(180, 82));

            rect = new RectangleF(190, 97, 30, 30);
            PdfLabColorSpace calGrayCS1 = new PdfLabColorSpace();
            calGrayCS1.Range = new double[] { 0.2, 1, 0.8, 23.5 };
            calGrayCS1.WhitePoint = new double[] { 0.2, 1, 0.8 };

            PdfLabColor red2 = new PdfLabColor(calGrayCS1);
            red2.L = 90;
            red2.A = 0.5;
            red2.B = 20;

            brush2 = new PdfSolidBrush(red2);
            g.DrawRectangle(brush2, rect);
            # endregion

            # region ICC Color
            g.DrawString("ICC Color", font, textBrush, new PointF(20, 134));
            rect = new RectangleF(30, 149, 30, 30);

            PdfCalRGBColorSpace calRgbCS3 = new PdfCalRGBColorSpace();
            calRgbCS3.Gamma = new double[] { 7.6, 5.1, 8.5 };
            calRgbCS3.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            calRgbCS3.WhitePoint = new double[] { 0.7, 1, 0.8 };

            // Read the ICC profile.
            FileStream fs = new FileStream(@"Assets\PDF\rgb.icc", FileMode.Open, FileAccess.Read);
            byte[] profileData = new byte[fs.Length];
            fs.Read(profileData, 0, profileData.Length);
            fs.Close();

            PdfICCColorSpace IccBasedCS4 = new PdfICCColorSpace();
            IccBasedCS4.ProfileData = profileData;
            IccBasedCS4.AlternateColorSpace = calRgbCS3;
            IccBasedCS4.ColorComponents = 3;
            IccBasedCS4.Range = new double[] { 0.0, 1.0, 0.0, 1.0, 0.0, 1.0 };
            PdfICCColor red4 = new PdfICCColor(IccBasedCS4);
            red4.ColorComponents = new double[] { 1, 0, 1 };
            brush2 = new PdfSolidBrush(red4);

            g.DrawRectangle(brush2, rect);
            #endregion

            #region Separation Color
            g.DrawString("Separation Color", font, textBrush, new PointF(100, 134));
            rect = new RectangleF(110, 149, 30, 30);

            PdfExponentialInterpolationFunction function = new PdfExponentialInterpolationFunction(true);
            float[] numArray = new float[3];
            numArray[0] = 90f;
            numArray[1] = 0.5f;
            numArray[2] = 20f;
            function.C1 = numArray;

            PdfLabColorSpace calLabCS8 = new PdfLabColorSpace();
            calLabCS8.Range = new double[] { 0.2, 1, 0.8, 23.5 };
            calLabCS8.WhitePoint = new double[] { 0.2, 1, 0.8 };

            PdfSeparationColorSpace colorspace8 = new PdfSeparationColorSpace();
            colorspace8.AlternateColorSpaces = calLabCS8;
            colorspace8.TintTransform = function;
            colorspace8.Colorant = "PANTONE Orange 021 C";
            PdfSeparationColor color8 = new PdfSeparationColor(colorspace8);
            color8.Tint = 0.7;

            brush2 = new PdfSolidBrush(color8);
            g.DrawRectangle(brush2, rect);
            # endregion

            # region Indexed Color
            g.DrawString("Indexed Color", font, textBrush, new PointF(180, 134));
            rect = new RectangleF(190, 149, 30, 30);

            PdfIndexedColorSpace colorspace7 = new PdfIndexedColorSpace();
            colorspace7.BaseColorSpace = new PdfDeviceColorSpace(PdfColorSpace.RGB);
            colorspace7.MaxColorIndex = 3;
            colorspace7.IndexedColorTable = new byte[] { 150, 0, 222, 255, 0, 0, 0, 255, 0, 0, 0, 255 };

            PdfIndexedColor color7 = new PdfIndexedColor(colorspace7);
            color7.SelectColorIndex = 3;

            brush2 = new PdfSolidBrush(color7);
            g.DrawRectangle(brush2, rect);
            # endregion

            # endregion

            document.Save("GraphicBrushes.pdf");
			document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("GraphicBrushes.pdf") { UseShellExecute = true };
                process.Start();
            }

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
