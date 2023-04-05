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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.starLoop(star1, 4000);
            this.starLoop(star2, 7000);
            this.starLoop(star3, 9000);

            this.bouncingButton();
        }

        private async Task starLoop(View view, uint duration)
        {
            while (true)
            {
                await view.RotateTo(360, duration);
                view.Rotation = 0;
            }
        }

        private async Task bouncingButton()
        {
            while (true)
            {
                await playButton.ScaleTo(1.1, 500);
                await playButton.ScaleTo(1, 500);
            }
        }

        private async void ButtonPlay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
        }
    }
}