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
    public partial class ListEventNotify : ContentPage
    {
        EventNotifyListModel viewModel;

        public ListEventNotify()
        {
            InitializeComponent();
            BindingContext = viewModel = new EventNotifyListModel();

        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as EventNotifyItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ReportSecurityIncidents(new EventNotifyModel(item)));

            // Manually deselect item.
            EventNotifyListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddReportSecurityIncidents()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.EventNotifyItems.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}