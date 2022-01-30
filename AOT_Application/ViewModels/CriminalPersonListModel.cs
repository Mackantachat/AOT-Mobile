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
    public class CriminalPersonListModel : BaseViewModel
    {
        public ObservableCollection<CriminalPersonItem> CriminalPersonItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CriminalPersonListModel()
        {
            Title = "บันทึกการกระทำผิดบุคคล";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            CriminalPersonItems = new ObservableCollection<CriminalPersonItem>();

            MessagingCenter.Subscribe<AddCriminalPerson, CriminalPersonItem>(this, "AddItem", async (obj, criminalPersonItem) =>
            {
                var newItem = criminalPersonItem as CriminalPersonItem;
                CriminalPersonItems.Add(newItem);
                await CPDataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                CriminalPersonItems.Clear();
                var criminalPersonItems = await CPDataStore.GetItemsAsync(true);
                foreach (var criminalPersonItem in criminalPersonItems)
                {
                    CriminalPersonItems.Add(criminalPersonItem);
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
