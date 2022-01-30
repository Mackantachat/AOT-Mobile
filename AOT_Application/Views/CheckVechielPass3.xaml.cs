using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckVechielPass3 : ContentPage
    {
        public CheckVechielPass3()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPass());
        }
        private async void upload(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPassUpload());
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPass());
        }
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPass2());
        }
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

            label0.Text = sw0.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label1.Text = sw1.IsToggled ? "ผ่าน" : "ไม่ผ่าน";

        }
    }
}