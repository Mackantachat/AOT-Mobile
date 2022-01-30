using System;
using Xamarin.Forms;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using AOT_Application.Models;
using AOT_Application.Views;
using System.Collections.Generic;

namespace AOT_Application.ViewModels
{
    public class CriminalVehicleListModel : BaseViewModel
    {
        public ObservableCollection<CriminalVehicleItem> CriminalVehicleItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CriminalVehicleListModel()
        {
            Title = "บันทึกการกระทำผิดยานพาหนะ";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            CriminalVehicleItems = new ObservableCollection<CriminalVehicleItem>();

            MessagingCenter.Subscribe<NewItemPage, CriminalVehicleItem>(this, "AddItem", async (obj, criminalVehicleItem) =>
            {
                var newItem = criminalVehicleItem as CriminalVehicleItem;
                CriminalVehicleItems.Add(newItem);
                await CriminalVehicleDataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                CriminalVehicleItems.Clear();
                var criminalVehicleItems = await CriminalVehicleDataStore.GetItemsAsync(true);
                foreach (var criminalVehicleItem in criminalVehicleItems)
                {
                    CriminalVehicleItems.Add(criminalVehicleItem);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
