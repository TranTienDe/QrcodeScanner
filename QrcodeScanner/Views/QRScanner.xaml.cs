using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Text;

namespace QrcodeScanner
{
	public partial class QRScanner : ContentPage
	{
		ZXingScannerView zxing;

		string URL = "http://login.grobest.com.vn/Traceability/Default.aspx";

		public QRScanner()
		{
			InitializeComponent();
			initCamera();
		}

		public void initCamera()
		{
			zxing = new ZXingScannerView()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			zxing.OnScanResult += (result) =>
				Device.BeginInvokeOnMainThread(
					async () => {
						zxing.IsAnalyzing = false;
					//await DisplayAlert("Barcode Scanned:", result.Text, "OK");
					edtID.Text = result.Text;
						if (!string.IsNullOrEmpty(edtID.Text))
						{
							URL += "?ID=" + edtID.Text + "&Value=0";
							await Navigation.PushAsync(new WebView(URL));
						}
				});
			
			cameraView.Children.Add(zxing);
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

		private void Handle_ClickedRefresh(object sender, System.EventArgs e)
		{
			edtID.Text = "";
		}

		private async void Handle_ClickedOK(object sender, System.EventArgs e)
		{
			if (!string.IsNullOrEmpty(edtID.Text))
			{
				URL += "?ID=" + edtID.Text + "&Value=0";
				await Navigation.PushAsync(new WebView(URL));
			}
			else {
				await DisplayAlert("Warning","QRcode null or empty","OK");
			}

		}

	}
}

