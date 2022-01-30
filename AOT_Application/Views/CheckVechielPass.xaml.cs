using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using AOT_Application.Models;
using AOT_Application.ViewModels;


namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckVechielPass : ContentPage
    {
        CheckVechielModel viewModel;

        public CheckVechielPass(CheckVechielModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

        }

        public CheckVechielPass()
        {
            InitializeComponent();

            var checkVechielItem = new CheckVechielItem
            {
        
            };

            viewModel = new CheckVechielModel(checkVechielItem);
            BindingContext = viewModel;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPassUpload());
        }
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPass2());
        }
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckVechielPass3());
        }
    }
}