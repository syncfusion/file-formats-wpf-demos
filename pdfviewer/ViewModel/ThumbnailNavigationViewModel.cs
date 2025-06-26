#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Windows;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Represents the view model class
    /// </summary>
    public class ThumbnailNavigationViewModel 
    {
        private Stream m_documentStream;

        /// <summary>
        /// Gets or sets the documnet path.
        /// </summary>
        public Stream DocumentStream
        {
            get
            {
                return m_documentStream;
            }
            set
            {
                m_documentStream = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailNavigationViewModel"/> class.
        /// </summary>
        public ThumbnailNavigationViewModel()
        {
            m_documentStream = GetFileStream("HTTP Succinctly.pdf");
        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
    }
}
