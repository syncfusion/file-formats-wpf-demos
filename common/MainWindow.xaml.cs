#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Navigation;
using Syncfusion.Windows.Shared;

namespace syncfusion.demoscommon.wpf
{
    public static class DemosNavigationService
    {
        public static NavigationService RootNavigationService
        {
            get; 
            set;
        }

        public static NavigationService DemoNavigationService
        {
            get;set;
        }

        public static Window MainWindow { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow(DemoBrowserViewModel viewModel)
        {
#if DEBUG
            if (DemoBrowserViewModel.CanAutomate)
            {
                BindingErrorListener.Listen(errorMessage => BindingErrorAutomation.OnBindingError(errorMessage, viewModel));
            }
#endif
            InitializeComponent();
            this.DataContext = viewModel;
            AISettings.DemoBrowserViewModel = viewModel;
            DemosNavigationService.MainWindow = this;
            ValidateCrendentials();
            DemosNavigationService.RootNavigationService = this.ROOTFRAME.NavigationService;
            DemosNavigationService.RootNavigationService.Navigate(new ProductsListView() { DataContext = viewModel });
            this.ROOTFRAME.NavigationService.Navigated += NavigationService_Navigated;
        }

        /// <summary>
        /// Helps to validate AI Credentials.
        /// </summary>
        private void ValidateCrendentials()
        {
            AISettings.DemoBrowserViewModel.ModelName = AISettings.ModelName;
            AISettings.DemoBrowserViewModel.Key = AISettings.Key;
            AISettings.DemoBrowserViewModel.EndPoint = AISettings.EndPoint;
            Task.Run(async () =>
            {
                await AISettings.ValidateCredentials();
            });
        }

        /// <summary>
        ///  Occurs when the content that is being navigated to has been found
        /// </summary>
        private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (DemosNavigationService.RootNavigationService.CanGoForward)
            {
                (this.DataContext as DemoBrowserViewModel).SelectedProduct = null;
            }
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new FakeWindowsPeer(this);
        }
    }

    public class FakeWindowsPeer : WindowAutomationPeer
    {
        public FakeWindowsPeer(Window window)
            : base(window)
        { }
        protected override List<AutomationPeer> GetChildrenCore()
        {
            return null;
        }
    }
}
