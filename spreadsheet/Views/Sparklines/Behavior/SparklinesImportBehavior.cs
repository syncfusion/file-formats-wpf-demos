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
using System.IO;
using Syncfusion.UI.Xaml.SpreadsheetHelper;
using Syncfusion.UI.Xaml.Spreadsheet.GraphicCells;

namespace syncfusion.spreadsheetdemos.wpf
{
    class SparklinesImportBehavior : FileImportBehavior
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.AddSparklineCellRenderer(new SparklineCellRenderer());
        } 
    }
}
