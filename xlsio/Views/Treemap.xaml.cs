#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
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
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Treemap.xaml
    /// </summary>
    public partial class Treemap : DemoControl
    {
        #region Constants
        private const string DEFAULTPATH = @"Assets\XlsIO\{0}";
        #endregion
        ExcelEngine excelEngine;

        # region Constructor
        /// <summary>
        /// Treemap constructor
        /// </summary>
        public Treemap()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();        
            excelEngine = new ExcelEngine();
            excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2016;
        }
        # endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region HelperMethods

        #region Get File Path
        /// <summary>
        /// Get the file path of input file and return the same
        /// </summary>
        /// <param name="inputPath">Input file</param>
        /// <returns>path of the input file</returns>
        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }
        #endregion       

        #endregion

        #region Creating 2016 Charts

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            #region Workbook Initialize
            //Get the path of the input file
            string inputPath = GetFullTemplatePath("TreemapTemplate.xlsx");
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputPath, ExcelOpenType.Automatic);
            #endregion

            IWorksheet sheet = workbook.Worksheets[0];
            IChart chart = null;
            if (this.rdbtnChartSheet.IsChecked != null && this.rdbtnChartSheet.IsChecked.Value)
                chart = workbook.Charts.Add();
            else
                chart = workbook.Worksheets[0].Charts.Add();

            #region Treemap Chart Settings
            chart.ChartType = ExcelChartType.TreeMap;
            chart.DataRange = sheet["A1:F13"];
            chart.ChartTitle = "Daily Food Sales";
            foreach (IChartSerie serie in chart.Series)
            {
                serie.SerieFormat.TreeMapLabelOption = ExcelTreeMapLabelOption.Banner;
            }
            #endregion
           
            chart.Legend.Position = ExcelLegendPosition.Top;


            if (this.rdbtnChartSheet.IsChecked != null && this.rdbtnChartSheet.IsChecked.Value)
                chart.Activate();
            else
            {
                workbook.Worksheets[0].Activate();
                IChartShape chartShape = chart as IChartShape;
                chartShape.TopRow = 1;
                chartShape.BottomRow = 22;
                chartShape.LeftColumn = 8;
                chartShape.RightColumn = 15;
            }

            #region Workbook Save and Close
            string outFileName = "Treemap_Chart.xlsx";
            workbook.SaveAs(outFileName);
            workbook.Close();
            #endregion

            OpenOutput(outFileName);
        }

        #region Open the Output File
        private void OpenOutput(string filename)
        {
            try
            {
                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        #endregion

        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            excelEngine.Dispose();
        }

        #region View the Input file
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Get the path of the input file
            string inputPath = GetFullTemplatePath("TreemapTemplate.xlsx");
            //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(inputPath) { UseShellExecute = true };
            process.Start();
        }
        #endregion

    }
}
