using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AOT_Application.Models;
using AOT_Application.ViewModels;

namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryCriminalVehicle : ContentPage
    {
        HistoryCriminalPersonListModel viewModel;
        public HistoryCriminalVehicle()
        {
            InitializeComponent();

            BindingContext = viewModel = new HistoryCriminalPersonListModel();

        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new HistoryCriminalVehicleDetail(new HistoryCriminalPersonModel(item)));

            // Manually deselect item.
            HistoryCriminalListView.SelectedItem = null;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}