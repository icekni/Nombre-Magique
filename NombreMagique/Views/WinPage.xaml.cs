using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NombreMagique.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WinPage : ContentPage
	{
		public WinPage (int magicNumber)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

			solution.Text = $"Le nombre magique etait : {magicNumber}";

			mainLayout.Scale = 0.7;
			mainLayout.ScaleTo(1, 2000);

            this.GoBack();
        }

		private async Task GoBack()
		{
			await Task.Delay(3000);
			await Navigation.PopToRootAsync();
		}
	}
}