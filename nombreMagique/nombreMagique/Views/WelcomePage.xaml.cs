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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

            // Disable navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
            // Animation
            InfiniteScale(this.playBtn, 1000);
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }

        private async Task InfiniteScale(View view, uint length)
        {
            do
            {
                await view.ScaleTo(1.1, length);
                await view.ScaleTo(1.0, length);
                view.Rotation = 0;
            } while (true);
        }
    }
}