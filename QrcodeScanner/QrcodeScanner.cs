using System;

using Xamarin.Forms;

namespace QrcodeScanner
{
	public class App : Application
	{
		public App()
		{
			//MainPage = new NavigationPage(content);
			//MainPage = new NavigationPage( new HomePage());
			//MainPage = new NavigationPage(new CustomPageCameraSmall());
			//MainPage = new MainPage();
			//MainPage = new Spacing();
			//MainPage = new ComplexLayout();
			MainPage = new NavigationPage(new QRScanner());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

