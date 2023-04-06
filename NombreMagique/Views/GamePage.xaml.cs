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
    public partial class GamePage : ContentPage
    {
        private const int NB_MIN = 1;
        private const int NB_MAX = 10;
        int magicNumber;

        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.pickNumber();
            hint.Text = $"Entre {NB_MIN} et {NB_MAX}";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            hint.Text = $"Entre {NB_MIN} et {NB_MAX}";
        }

        public void pickNumber()
        {
            this.magicNumber = new Random().Next(NB_MIN, NB_MAX);
        }

        private void ButtonGuess_Clicked(object sender, EventArgs e)
        {
            int numberGuessed;

            if (int.TryParse(number.Text, out numberGuessed))
            {
                if (numberGuessed > NB_MAX || numberGuessed < NB_MIN)
                {
                    DisplayAlert("Nombre Magique", $"Entre {NB_MIN} et {NB_MAX} on a dit!", "OK");
                    number.Text = null;
                    number.Focus();
                    return;
                }

                if (numberGuessed > magicNumber)
                {
                    DisplayAlert("Nombre magique", "C'est moins", "OK");
                    number.Focus();
                    return;
                }
                if (numberGuessed < magicNumber)
                {
                    DisplayAlert("Nombre magique", "C'est plus", "OK");
                    number.Focus();
                    return;
                }

                if (numberGuessed == magicNumber)
                {
                    this.winAction();
                    return;
                }
            }
            else
            {
                DisplayAlert("Nombre magique", "Nombre non reconnu", "OK");
                number.Text = null;
                number.Focus();
                return;
            }
        }

        private async Task winAction()
        {
            await DisplayAlert("Nombre magique", "C'est gagné", "OK");
            await this.Navigation.PopAsync();
        }
    }
}