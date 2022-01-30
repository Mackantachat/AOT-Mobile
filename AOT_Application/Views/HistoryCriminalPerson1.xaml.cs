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
    

    public partial class HistoryCriminalPerson1 : ContentPage
    {
        HistoryCriminalPersonListModel viewModel2;
        public HistoryCriminalPerson1()
        {
            InitializeComponent();

            BindingContext = viewModel2 = new HistoryCriminalPersonListModel();

        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new HistoryCriminalPerson(new HistoryCriminalPersonModel(item)));

            // Manually deselect item.
            HistoryCriminalListView.SelectedItem = null;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel2.Items.Count == 0)
                viewModel2.LoadItemsCommand.Execute(null);
        }

    }
}