using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AOT_Application.Models;
using AOT_Application.Views;
using AOT_Application.ViewModels;
using System.ComponentModel;
using AOT_Application.Services;

namespace AOT_Application.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]

    public partial class ListVeciel : ContentPage
    {
        CheckVechielListModel viewModel;
        public ListVeciel()
        {
            InitializeComponent();

            DependencyService.Register<ApiCheckVehicleDataStore>();

            BindingContext = viewModel = new CheckVechielListModel();

        }

        private async void btnScan_Clicked(object sender, EventArgs e) 
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CheckVechielItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new CheckVechielPass(new CheckVechielModel(item)));



            // Manually deselect item.
            VecielListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.CheckVechielItems.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}