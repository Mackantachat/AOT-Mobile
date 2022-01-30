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
using Xamarin.Essentials;

namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]

    public partial class ListCriminalVehicle : ContentPage
    {
        CriminalVehicleListModel viewModel;

        public ListCriminalVehicle()
        {
            InitializeComponent();

            DependencyService.Register<ApiCriminalVehicleDataStore>();

            BindingContext = viewModel = new CriminalVehicleListModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CriminalVehicleItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new CriminalVehicleDetails(new CriminalVehicleModel(item)));

            // Manually deselect item.
            CriminalVehicleListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.CriminalVehicleItems.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}