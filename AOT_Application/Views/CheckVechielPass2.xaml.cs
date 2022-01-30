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
    public partial class CheckVechielPass2 : ContentPage
    {
        public CheckVechielPass2()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPassUpload());
        }
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPass());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPass3());
        }
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

            label0.Text = sw0.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label1.Text = sw1.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label2.Text = sw2.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label3.Text = sw3.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label4.Text = sw4.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label5.Text = sw5.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label6.Text = sw6.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label7.Text = sw7.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label8.Text = sw8.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label9.Text = sw9.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label10.Text = sw10.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label11.Text = sw11.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label12.Text = sw12.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label13.Text = sw13.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label14.Text = sw14.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label15.Text = sw15.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label16.Text = sw16.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label17.Text = sw17.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label18.Text = sw18.IsToggled ? "ผ่าน" : "ไม่ผ่าน";
            label19.Text = sw19.IsToggled ? "ผ่าน" : "ไม่ผ่าน";

        }

    }
}