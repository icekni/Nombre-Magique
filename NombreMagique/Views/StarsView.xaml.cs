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
    public partial class StarsView : ContentView
    {
        public StarsView()
        {
            InitializeComponent();

            this.starLoop(star1, 4000);
            this.starLoop(star2, 7000);
            this.starLoop(star3, 9000);
        }

        private async Task starLoop(View view, uint duration)
        {
            while (true)
            {
                await view.RotateTo(360, duration);
                view.Rotation = 0;
            }
        }
    }
}