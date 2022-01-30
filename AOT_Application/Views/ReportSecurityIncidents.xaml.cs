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
using AOT_Application.Services;
using System.IO;

namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportSecurityIncidents : ContentPage
    {
        EventNotifyModel viewModel;

        public ReportSecurityIncidents(EventNotifyModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

        }
        public ReportSecurityIncidents()
        {
            InitializeComponent();

            var item = new EventNotifyItem
            { 
               
            };

            viewModel = new EventNotifyModel(item);
            BindingContext = viewModel;
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