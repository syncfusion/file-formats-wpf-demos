#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.xlsiodemos.wpf
{
    public class XlsIODemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new XlsIOProductDemos());
            return productdemos;
        }
    }
    public class XlsIOProductDemos : ProductDemo
    {
        public XlsIOProductDemos()
        {
            this.Product = "XlsIO";
            this.ProductCategory = "FILE FORMAT";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M2.5 14H11.5C12.88 14 14 12.88 14 11.5V2.5C14 1.12 12.88 0 11.5 0H2.5C1.12 0 0 1.12 0 2.5V11.5C0 12.88 1.12 14 2.5 14ZM1 2.5C1 1.67 1.67 1 2.5 1H11.5C12.33 1 13 1.67 13 2.5V11.5C13 12.33 12.33 13 11.5 13H2.5C1.67 13 1 12.33 1 11.5V2.5ZM9.15891 10.0391L7.20891 6.91907H7.21891L9.16891 3.78906H8.02891L6.69891 6.07907L5.27891 3.78906H4.12891L6.07891 6.91907L4.13891 10.0391H5.27891L6.59891 7.76907L8.00891 10.0391H9.15891Z"),
                Width = 14,
                Height = 14,
            };
            this.IsHighlighted = true;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileFormat.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "Syncfusion XlsIO is a .NET class library to create, read, edit and modify Microsoft Excel documents along with conversion of Excel documents to PDF and image.";
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/XlsIO.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Budget Planner",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This sample demonstrates how to create a simple Budget planner using XlsIO.",
                DemoViewType = typeof(BudgetPlanner)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Attendance Tracker",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This sample demonstrates how to use Attendance Tracker in spreadsheets using XlsIO.",
                DemoViewType = typeof(AttendanceTracker)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Call Center Dashboard",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This sample demonstrates how to create a simple Call Center dashboard using XlsIO.",
                DemoViewType = typeof(CallCenterDashboard)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Create Spreadsheet",
                GroupName = "GETTING STARTED",
                Description = "This sample demonstrates how to create a simple Excel document with formulas and formatting using XlsIO.",
                DemoViewType = typeof(CreateSpreadsheet)
            });

			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Find And Extract",
                GroupName = "GETTING STARTED",
                Description = "This sample demonstrates how to extract data from a spreadsheet using XlsIO.",
                DemoViewType = typeof(FindAndExtract)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Replace Options",
                GroupName = "GETTING STARTED",
                Description = "This sample demonstrates how to replace text in a spreadsheet using XlsIO.",
                DemoViewType = typeof(ReplaceOptions)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Conditional Formatting",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply conditional formats using XlsIO.",
                DemoViewType = typeof(ConditionalFormatting)
            });

			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Format Cells",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply formatting to the cells using XlsIO.",
                DemoViewType = typeof(FormatCells)
            });

			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Styles And Formatting",
                GroupName = "FORMATTING",
                Description = "This sample demonstrates how to apply styles and formatting using XlsIO.",
                DemoViewType = typeof(StylesAndFormatting)
            });
          
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Formula",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use formulas in spreadsheets using XlsIO.",
                DemoViewType = typeof(Formula)
            });

			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Compute All Formulas",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use formulas in spreadsheets using XlsIO.",
                DemoViewType = typeof(ComputeAllFormulas)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Compute Specific Formula",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates the calculation of formula entered during run time using the calculate engine.",
                DemoViewType = typeof(ComputeSpecificFormula)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Table Formula",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use table formula in spreadsheets using XlsIO.",
                DemoViewType = typeof(TableFormula)
            });
					
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "External Formula",
                GroupName = "FORMULAS",
                Description = "This sample demonstrates how to use external formula in spreadsheets using XlsIO.",
                DemoViewType = typeof(ExternalFormula)
            });
		
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Data Validation",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use data validation in spreadsheets using XlsIO.",
                DemoViewType = typeof(DataValidation)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Form Controls",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use form controls in spreadsheet using XlsIO.",
                DemoViewType = typeof(FormControls)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Interactive Features",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use interactive features in spreadsheet using XlsIO.",
                DemoViewType = typeof(InteractiveFeatures)
            });
			
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Ole Object",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to use OLE objects in spreadsheet using XlsIO.",
                DemoViewType = typeof(OleObject)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Performance",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates the performance of XlsIO when handling larger files.",
                DemoViewType = typeof(Performance)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Range Manipulation",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to manipulate cells in a spreadsheet using XlsIO.",
                DemoViewType = typeof(RangeManipulation)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Sorting",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to perform sorting in a spreadsheet using XlsIO.",
                DemoViewType = typeof(Sorting)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Filters",
                GroupName = "DATA MANAGEMENT",
                Description = "This sample demonstrates how to apply filters in a spreadsheet using XlsIO.",
                DemoViewType = typeof(Filters)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Slicer",
                GroupName = "DATA MANAGEMENT",
                Description = "The sample shows how to create and use slicers in table.",
                DemoViewType = typeof(Slicer)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "What-If Analysis",
                GroupName = "DATA MANAGEMENT",
                Description = "The sample shows how to create different scenarios of What-If Analysis.",
                DemoViewType = typeof(WhatIfAnalysis)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Import Export Data Table",
                GroupName = "DATA BINDING",
                Description = "This sample demonstrates exporting data from Excel to a data table, and import data from the data table to the Grid.",
                DemoViewType = typeof(ImportExportDataTable)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Template Marker",
                GroupName = "DATA BINDING",
                Description = "This sample demonstrates how to use Template Markers in spreadsheets using XlsIO.",
                DemoViewType = typeof(TemplateMarker)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Collection Objects",
                GroupName = "DATA BINDING",
                Description = "This sample demonstrates how to use Collection Objects in spreadsheets using XlsIO.",
                DemoViewType = typeof(CollectionObjects)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Import Nested Collection",
                GroupName = "DATA BINDING",
                Description = "This sample demonstrates how to import data directly from nested collection objects with import data layout and group options in spreadsheets using XlsIO.",
                DemoViewType = typeof(ImportNestedCollection)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Import HTML Table",
                GroupName = "DATA BINDING",
                Description = "This sample demonstrates how to convert HTML table to worksheet using Essential XlsIO.",
                DemoViewType = typeof(ImportHTMLTable)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Chart Worksheet",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create a simple chart sheet using XlsIO.",
                DemoViewType = typeof(ChartWorksheet)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Embedded Chart",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create a simple chart using XlsIO.",
                DemoViewType = typeof(EmbeddedChart)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Sparklines",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create sparkline charts using XlsIO.",
                DemoViewType = typeof(Sparklines)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Box and Whisker",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Box and Whisker chart using XlsIO.",
                DemoViewType = typeof(BoxAndWhisker)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Funnel Chart",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Funnel chart using XlsIO.",
                DemoViewType = typeof(Funnel)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Treemap",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Treemap chart using XlsIO.",
                DemoViewType = typeof(Treemap)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Sunburst",
                GroupName = "CHARTS",
                Description = "This sample demonstrates how to create Sunburst chart using XlsIO.",
                DemoViewType = typeof(Sunburst)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Row Column Manipulation",
                GroupName = "SHEET MANAGEMENT",
                Description = "This sample demonstrates how to customize rows and columns in a spreadsheet using XlsIO.",
                DemoViewType = typeof(RowColumnManipulation)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Worksheet Management",
                GroupName = "SHEET MANAGEMENT",
                Description = "This sample demonstrates how to customize spreadsheets using XlsIO.",
                DemoViewType = typeof(WorksheetManagement)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To PDF",
                GroupName = "CONVERSIONS",
                Description = "This sample demonstrates how to convert Excel spreadsheets to PDF document using XlsIO.",
                DemoViewType = typeof(ExcelToPDF)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To PDF/UA",
                GroupName = "CONVERSIONS",
                Description = "This sample demonstrates how to convert Excel spreadsheets to PDF/UA document using XlsIO.",
                DemoViewType = typeof(ExcelToPDFUA)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Worksheet To HTML",
                GroupName = "CONVERSIONS",
                Description = "This sample demonstrates how to convert Excel spreadsheets to HTML document using XlsIO.",
                DemoViewType = typeof(WorksheetToHTML)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Worksheet To Image",
                GroupName = "CONVERSIONS",
                Description = "This sample demonstrates how to convert spreadsheets to image using XlsIO.",
                DemoViewType = typeof(WorksheetToImage)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To ODS",
                GroupName = "CONVERSIONS",
                Description = "This sample demonstrates how to convert Excel spreadsheets to OpenDocument spreadsheets using XlsIO.",
                DemoViewType = typeof(ExcelToODS)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Print",
                GroupName = "CONVERSIONS",
                Description = "This sample demonstrates how to convert Excel spreadsheets to PDF document and print the converted PDF document using XlsIO.",
                DemoViewType = typeof(Print)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To JSON",
                GroupName = "CONVERSIONS",
                Description = "This sample demonstrates the conversion of Excel documents to JSON file using Essential XlsIO.",
                DemoViewType = typeof(ExcelToJSON)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Document Settings",
                GroupName = "SETTINGS",
                Description = "This sample demonstrates how to include document properties to spreadsheets using XlsIO.",
                DemoViewType = typeof(DocumentSettings)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Encrypt and Decrypt",
                GroupName = "SETTINGS",
                Description = "This sample demonstrates how to encrypt and decrypt workbooks using XlsIO.",
                DemoViewType = typeof(EncryptAndDecrypt)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Workbook Protection",
                GroupName = "SETTINGS",
                Description = "This sample demonstrates how to set protection for a workbook using XlsIO.",
                DemoViewType = typeof(WorkbookProtection)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Worksheet Protection",
                GroupName = "SETTINGS",
                Description = "This sample demonstrates how to Lock and Unlock spreadsheets using XlsIO.",
                DemoViewType = typeof(WorksheetProtection)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Pivot Chart",
                GroupName = "BUSINESS INTELLIGENCE",
                Description = "This sample demonstrates how to use Pivot Charts in spreadsheets using XlsIO.",
                DemoViewType = typeof(PivotChart)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Pivot Table",
                GroupName = "BUSINESS INTELLIGENCE",
                Description = "This sample demonstrates how to use PivotTable in spreadsheets using XlsIO.",
                DemoViewType = typeof(PivotTable)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Pivot Table Layout",
                GroupName = "BUSINESS INTELLIGENCE",
                Description = "This sample deomonstrates how to layout pivot table using XlsIO.",
                DemoViewType = typeof(PivotTableLayout)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Tables",
                GroupName = "BUSINESS INTELLIGENCE",
                Description = "This sample deomonstrates how to use tables in spreadsheets using XlsIO.",
                DemoViewType = typeof(Tables)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "AutoShapes",
                GroupName = "SHAPES",
                Description = "This sample demonstrates how to use AutoShapes in spreadsheets using XlsIO.",
                DemoViewType = typeof(AutoShape)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Group Shapes",
                GroupName = "SHAPES",
                Description = "This sample demonstrates how to use group shapes in spreadsheets using XlsIO.",
                DemoViewType = typeof(GroupShape)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Comments",
                GroupName = "SHAPES",
                Description = "This sample demonstrates how to add notes and comments in spreadsheets using XlsIO.",
                DemoViewType = typeof(Comments)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Create Macro",
                GroupName = "MACRO",
                Description = "This sample demonstrates how to create macros in spreadsheets using XlsIO.",
                DemoViewType = typeof(CreateMacro)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Edit Macro",
                GroupName = "MACRO",
                Description = "This sample demonstrates how to edit macros in spreadsheets using XlsIO.",
                DemoViewType = typeof(EditMacro)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Yearly Sales",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This demo shows the product sales of a company for each month in a specific year by visualizing the data with charts.",
                DemoViewType = typeof(YearlySales)
            });

            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Expenses Report",
                GroupName = "PRODUCT SHOWCASE",
                Description = "This demo shows a expenses report with the difference between expected cost and actual cost for the different categories of a company’s expenses.",
                DemoViewType = typeof(ExpensesReport)
            });

        }
    }
}

