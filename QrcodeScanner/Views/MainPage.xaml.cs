using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QrcodeScanner
{
	public partial class MainPage : ContentPage
	{
		
		ZXingScannerView zxing;

		public MainPage()
		{
			InitializeComponent();
			initCamera();
		}
		public void initCamera()
		{
			zxing = new ZXingScannerView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			zxing.OnScanResult += (result) =>
				Device.BeginInvokeOnMainThread(
					async () => {
						zxing.IsAnalyzing = false;
						await DisplayAlert("Barcode Scanned:", result.Text, "OK");
				});

			gridView.Children.Add(zxing);
	
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			zxing.IsScanning = true;
		} 

		protected override void OnDisappearing()
		{
			zxing.IsScanning = false;
			base.OnDisappearing();
		}
	}
}

