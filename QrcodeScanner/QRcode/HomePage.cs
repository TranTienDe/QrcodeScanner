using System;
using Xamarin.Forms;

namespace QrcodeScanner
{
	public class HomePage: ContentPage
	{
		public HomePage()
		{
			Button button = new Button
			{
				Text ="Scan customPage"
			};
			button.Clicked += async delegate {
				var customPage = new CustomPage();
				await Navigation.PushAsync(customPage);
			};

			var stack = new StackLayout();
			stack.Children.Add(button);

			Content = stack;
		}
	}
}

