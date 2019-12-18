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
    public partial class StarsView : ContentView
    {
        public StarsView()
        {
            InitializeComponent();

            // Animations
            InfiniteRotation(this.star1img, 4000);
            InfiniteRotation(this.star2img, 7000);
            InfiniteRotation(this.star3img, 9000);
        }

        private async Task InfiniteRotation(View view, uint length)
        {
            do
            {
                await view.RotateTo(360, length);
                view.Rotation = 0;
            } while (true);
        }
    }
}