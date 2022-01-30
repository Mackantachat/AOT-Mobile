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
using AOT_Application.Views;


namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]

    public partial class CriminalVehicleDetails : TabbedPage
    {
        CriminalVehicleModel viewModel;

        public CriminalVehicleDetails(CriminalVehicleModel viewModel)
        {
            InitializeComponent();
            

        }
        public CriminalVehicleDetails()
        {
            InitializeComponent();

            var criminalVehicleItem = new CriminalVehicleItem
            {
               
            };

            viewModel = new CriminalVehicleModel(criminalVehicleItem);
            BindingContext = viewModel;

        }
    }
}