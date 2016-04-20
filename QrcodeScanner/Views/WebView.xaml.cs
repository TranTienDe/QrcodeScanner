using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QrcodeScanner
{
	public partial class WebView : ContentPage
	{
		public WebView(string URL)
		{
			InitializeComponent();
			Browser.Source = URL;

		}

		private void WebOnNavigating(object sender, WebNavigationEventArgs e)
		{
			activityIndicator.IsVisible = true;
		}

		private void WebOnEndNavigating(object sender, WebNavigationEventArgs e)
		{
			activityIndicator.IsVisible = false;
		}

	}
}

