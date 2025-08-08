#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Windows.Shapes;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return message.Text; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    message.Text = value;
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.Owner = null;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public static void Show(string message)
        {
            ErrorLogging.LogError(message);
            var errorWindow = new ErrorWindow();
            errorWindow.Message = message;
            if (DemosNavigationService.MainWindow != null)
            {
                errorWindow.Owner = DemosNavigationService.MainWindow;
            }
            errorWindow.ShowDialog();
        }
    }
}
