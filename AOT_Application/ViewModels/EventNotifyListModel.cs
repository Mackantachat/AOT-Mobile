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
    public class EventNotifyListModel : BaseViewModel
    {
        public ObservableCollection<EventNotifyItem> EventNotifyItems { get; set; }
        public Command LoadItemsCommand { get; set; }
        public EventNotifyListModel()
        {
            Title = "รายงานแจ้งเหตุการณ์";
            EventNotifyItems = new ObservableCollection<EventNotifyItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AddReportSecurityIncidents, EventNotifyItem>(this, "AddItem", async (obj, eventNotifyItem) =>
            {
                var newItem = eventNotifyItem as EventNotifyItem;
                EventNotifyItems.Add(newItem);
                await EventNotifyDataStore.AddItemAsync(newItem);
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                EventNotifyItems.Clear();
                var eventNotifyItems = await EventNotifyDataStore.GetItemsAsync(true);
                foreach (var eventNotifyItem in eventNotifyItems)
                {
                    EventNotifyItems.Add(eventNotifyItem);
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
  






