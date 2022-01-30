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

    public partial class ListCriminalPerson : ContentPage
    {
        CriminalPersonListModel viewModel;

        public ListCriminalPerson()
        {
            InitializeComponent();

            DependencyService.Register<ApiCriminalPersonDataStore>();

            BindingContext = viewModel = new CriminalPersonListModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CriminalPersonItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new CriminalPersonDetails(new CriminalPersonModel(item)));

            // Manually deselect item.
            CriminalPersonListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.CriminalPersonItems.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
            
        }

        private async void Button_ClickedAdd(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddCriminalPerson()));
        }
    }
}