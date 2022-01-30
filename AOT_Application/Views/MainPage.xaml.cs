using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AOT_Application.Models;

namespace AOT_Application.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Login, (NavigationPage)Detail);

        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Login:
                        MenuPages.Add(id, new NavigationPage(new Login()));
                        break;
                    //case (int)MenuItemType.Browse:
                    //    MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                    //    break;
                    //case (int)MenuItemType.About:
                    //    MenuPages.Add(id, new NavigationPage(new AboutPage()));
                    //    break;
                    case (int)MenuItemType.ListFierExtinguisher:
                        MenuPages.Add(id, new NavigationPage(new ListFierExtinguisher()));   
                        break;
                    case (int)MenuItemType.ListVeciel:
                        MenuPages.Add(id, new NavigationPage(new ListVeciel()));
                        break;
                    case (int)MenuItemType.ListCriminalPerson:
                        MenuPages.Add(id, new NavigationPage(new ListCriminalPerson()));
                        break;
                    case (int)MenuItemType.ListCriminalVehicle:
                        MenuPages.Add(id, new NavigationPage(new ListCriminalVehicle()));
                        break;
                    case (int)MenuItemType.ListEventNotify:
                        MenuPages.Add(id, new NavigationPage(new ListEventNotify()));
                        break;
                    case (int)MenuItemType.ItemsPage:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}