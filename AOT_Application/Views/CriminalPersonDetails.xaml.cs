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

    public partial class CriminalPersonDetails : TabbedPage
    {
        CriminalPersonModel viewModel;

        public CriminalPersonDetails(CriminalPersonModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel; 
        }


        public CriminalPersonDetails()
        {
            InitializeComponent();

            var criminalPersonItem = new CriminalPersonItem
            {
            };

            viewModel = new CriminalPersonModel(criminalPersonItem);
            BindingContext = viewModel;
        }
    }


}