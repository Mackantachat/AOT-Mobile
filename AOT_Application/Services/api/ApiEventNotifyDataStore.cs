using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using AOT_Application.Models;
using AOT_Application.Views;

namespace AOT_Application.Services.api
{
    public class ApiEventNotifyDataStore : EventNotifyDataStore<EventNotifyItem>
    {
        HttpClient client;
        IEnumerable<EventNotifyItem> eventNotifyItems;
        public ApiEventNotifyDataStore()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri($"{App.AzureBackendUrl}");

            eventNotifyItems = new List<EventNotifyItem>();
        }
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<EventNotifyItem>> GetItemsAsync(bool forceRefresh = false)
        {

            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"Operation");
                eventNotifyItems = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<EventNotifyItem>>(json));
            }
            return eventNotifyItems;
        }
        public async Task<EventNotifyItem> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"Operation/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<EventNotifyItem>(json));
            }

            return null;
        }
        public async Task<bool> AddItemAsync(EventNotifyItem eventNotifyItem)
        {
            if (eventNotifyItem == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(eventNotifyItem);

            var response = await client.PutAsync($"Operation", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateItemAsync(EventNotifyItem eventNotifyItem)
        {
            if (eventNotifyItem == null || eventNotifyItem.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(eventNotifyItem);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"{eventNotifyItem.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
