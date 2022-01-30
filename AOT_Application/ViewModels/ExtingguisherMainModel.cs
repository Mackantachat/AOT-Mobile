using System;
using Xamarin.Forms;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using AOT_Application.Models;
using AOT_Application.Views;
using System.Collections.Generic;
using AOT_Application.Services;

namespace AOT_Application.ViewModels
{
    public class ExtingguisherMainModel : BaseViewModel
    {
        public ObservableCollection<ExtingguisherItem> ExtingguisherItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ExtingguisherMainModel()
        {
            Title = "งานตรวจสภาพถังดับเพลิง";
            ExtingguisherItems = new ObservableCollection<ExtingguisherItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, ExtingguisherItem>(this, "AddItem", async (obj, extingguisherItem) =>
            {
                var newItem = extingguisherItem as ExtingguisherItem;
                ExtingguisherItems.Add(newItem);
                await ExtingguisherDataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ExtingguisherItems.Clear();
                var extingguisherItems = await ExtingguisherDataStore.GetItemsAsync(true);
                foreach (var extingguisherItem in extingguisherItems)
                {
                    ExtingguisherItems.Add(extingguisherItem);
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