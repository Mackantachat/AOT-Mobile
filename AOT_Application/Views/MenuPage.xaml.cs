using AOT_Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AOT_Application.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                //new HomeMenuItem {Id = MenuItemType.Login, Title="Login" },
                //new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" }, 
                //new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.ListFierExtinguisher, Title="งานตรวจสภาพถังดับเพลิง" },
                new HomeMenuItem {Id = MenuItemType.ListVeciel, Title="งานตรวจสภาพยานพาหนะ" },
                new HomeMenuItem {Id = MenuItemType.ListCriminalPerson, Title="บันทึกการกระทำผิดบุคคล" },
                new HomeMenuItem {Id = MenuItemType.ListCriminalVehicle, Title="บันทึกการกระทำผิดยานพาหนะ" },
                new HomeMenuItem {Id = MenuItemType.ListEventNotify, Title="รายการแจ้งเหตุการณ์" },
                new HomeMenuItem {Id = MenuItemType.ItemsPage, Title="test" }

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}