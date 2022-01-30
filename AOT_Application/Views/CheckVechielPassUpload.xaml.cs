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
using System.IO;

namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]

    public partial class CheckVechielPassUpload : ContentPage
    {
        ItemsViewModel viewModel;
        public CheckVechielPassUpload()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatusFierExtingguisher());
        }
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatusFierExtingguisher());
        }
        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

        }
    }
}