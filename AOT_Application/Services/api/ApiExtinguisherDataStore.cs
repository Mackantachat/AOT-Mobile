using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using AOT_Application.Models;
using AOT_Application.Views;

namespace AOT_Application.Services
{
    public class ApiExtinguisherDataStore : ExtingguisherDataStore<ExtingguisherItem>
    {
        HttpClient client;
        IEnumerable<ExtingguisherItem> extingguisherItems;

        
        public ApiExtinguisherDataStore()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri($"{App.AzureBackendUrl}");

            extingguisherItems = new List<ExtingguisherItem>();

        }
       
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<ExtingguisherItem>> GetItemsAsync(bool forceRefresh = false)
        {
            
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"InspectFireExtinguisher");
                extingguisherItems = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<ExtingguisherItem>>(json));
            }
            return extingguisherItems;
        }

        public async Task<ExtingguisherItem> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"InspectFireExtinguisher/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<ExtingguisherItem>(json));
            }

            return null;
        }
        
        public async Task<bool> AddItemAsync(ExtingguisherItem extingguisherItem)
        {
            if (extingguisherItem == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(extingguisherItem);

            var response = await client.PutAsync($"InspectFireExtinguisher", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(ExtingguisherItem extingguisherItem)
        {
            if (extingguisherItem == null || extingguisherItem.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(extingguisherItem);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"{extingguisherItem.Id}"), byteContent);

            return response.IsSuccessStatusCode;
            //var client = new HttpClient();

            //    // TODO add some error handling
            //    var method = new HttpMethod("PATCH");

            //    var request = new HttpRequestMessage(method, extingguisherItem)
            //    {
            //        Content = ExtingguisherItem
            //    };
            //client.PatchAsync(url, new StringContent(
            //                   JsonConvert.SerializeObject(add_list_to_folder),
            //                   Encoding.UTF8, "application/json"));

            //return await client.SendAsync(request);
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
