using System;
using Xamarin.Forms;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using AOT_Application.Models;
using AOT_Application.Views;

namespace AOT_Application.ViewModels
{
    public class CheckVechielListModel : BaseViewModel
    {
        public ObservableCollection<CheckVechielItem> CheckVechielItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CheckVechielListModel()
        {
            Title = "งานตรวจสภาพยานพาหนะ";
            CheckVechielItems = new ObservableCollection<CheckVechielItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, CheckVechielItem>(this, "AddItem", async (obj, checkVechielItem) =>
            {
                var newItem = checkVechielItem as CheckVechielItem;
                CheckVechielItems.Add(newItem);
                await CheckVehicleDataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                CheckVechielItems.Clear();
                var checkVechielItems = await CheckVehicleDataStore.GetItemsAsync(true);
                foreach (var checkVechielItem in checkVechielItems)
                {
                    CheckVechielItems.Add(checkVechielItem);
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