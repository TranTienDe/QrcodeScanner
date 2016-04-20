using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QrcodeScanner
{
	public class CustomPageCameraSmall: ContentPage
	{
		ZXingScannerView zxing;
		ZXingDefaultOverlay overlay;

		public CustomPageCameraSmall() : base()
		{
			zxing = new ZXingScannerView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			zxing.OnScanResult += (result) =>
				Device.BeginInvokeOnMainThread(
					async () =>
					{
						zxing.IsAnalyzing = false;
						await DisplayAlert("Scanned barcode: ", result.Text, "OK");
						await Navigation.PopAsync();
					}
				);

			overlay = new ZXingDefaultOverlay()
			{
				TopText = "Hold your phone up to the barcode",
				BottomText = "Scanning will happen automatically",
				ShowFlashButton = zxing.HasTorch,
			};
			overlay.FlashButtonClicked += (sender, e) =>
			{
				zxing.IsTorchOn = !zxing.IsTorchOn;
			};

			var grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			grid.Children.Add(zxing);
			//grid.Children.Add(overlay);

			Content = grid;
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

