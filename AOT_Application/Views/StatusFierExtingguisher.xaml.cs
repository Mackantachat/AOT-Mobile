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
    [DesignTimeVisible(false)]

    public partial class StatusFierExtingguisher : ContentPage
    {
        ExtingguisherModel viewModel;
        public StatusFierExtingguisher(ExtingguisherModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        public StatusFierExtingguisher()
        {
            InitializeComponent();

            var extingguisherItem = new ExtingguisherItem
            {
                EtlSystem = "Item 1",
                EtlTable = "This is an item description."
            };

            viewModel = new ExtingguisherModel(extingguisherItem);
            BindingContext = viewModel;

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatusFierExtingguisherUpload());
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatusFierExtingguisher2());
        }



    }
}