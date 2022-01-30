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
    public partial class StatusFierExtingguisher2 : ContentPage
    {
        public StatusFierExtingguisher2()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatusFierExtingguisher());
        }
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatusFierExtingguisher());
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            label0.Text = sw0.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label1.Text = sw1.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label2.Text = sw2.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label3.Text = sw3.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label4.Text = sw4.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label5.Text = sw5.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
        }

        private async void upload(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatusFierExtingguisherUpload());

        }
    }
}