using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nombreMagique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WinPage : ContentPage
    {
        public WinPage(int magicNumber = 0)
        {
            InitializeComponent();

            // Disable navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
            // Anime page
            AnimeLayout(this.stklytMain);
            // Get value of magic number
            this.lblMagicNumber.Text = $"Le nombre magique était: {magicNumber}";
            // Go to root page
            NavigateBackToWelcomePage();
        }

        private async Task NavigateBackToWelcomePage()
        {
            await Task.Delay(5000);
            await Navigation.PopToRootAsync();
        }

        private async Task AnimeLayout(View view)
        {
            view.Scale = 0.7;
            await view.ScaleTo(1.0, 1500, Easing.BounceIn);
        }
    }
}