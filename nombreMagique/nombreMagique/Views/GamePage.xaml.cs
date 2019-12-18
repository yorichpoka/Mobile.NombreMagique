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
    public partial class GamePage : ContentPage
    {
        private int _MagicNumber { get; set; }
        private const int NB_MIN = 1;
        private const int NB_MAX = 10;

        public GamePage()
        {
            InitializeComponent();

            // Disable navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
            // Set lblConsValues
            this.lblConsValues.Text = $"Entre {NB_MIN} et {NB_MAX}";
            // Generate magicnumber
            this._MagicNumber = new Random().Next(NB_MIN, NB_MAX);
            // Focus on entry
            this.numberEntry.Focus();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var number = Int32.Parse(this.numberEntry.Text);

                if (!(NB_MIN <= number && number <= NB_MAX))
                    throw new Exception();

                if (number > this._MagicNumber)
                    DisplayAlert("Oops", "Le nombre magique est plus petit", "OK");
                else if (number < this._MagicNumber)
                    DisplayAlert("Oops", "Le nombre magique est plus grand", "OK");
                else
                    // Win action
                    WinAction(number);
            }
            catch (Exception)
            {
                DisplayAlert("Oops", $"Vous devez entrer un nombre entre {NB_MIN} et {NB_MAX}", "OK");
            }

            // Clear value
            this.numberEntry.Text = null;
        }

        private async Task WinAction(int number)
        {
            // Go to the win page
            await Navigation.PushAsync(
                new WinPage(number)
            );
        }
    }
}