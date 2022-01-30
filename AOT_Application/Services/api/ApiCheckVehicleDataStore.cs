using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using AOT_Application.Models;
using AOT_Application.Views;
using AOT_Application.Services;

namespace AOT_Application.Services
{
    public class ApiCheckVehicleDataStore : CheckVehicleDataStore<CheckVechielItem>
    {
        HttpClient client;
        IEnumerable<CheckVechielItem> checkVechielItems;

        public ApiCheckVehicleDataStore()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri($"{App.AzureBackendUrl}");

            checkVechielItems = new List<CheckVechielItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<CheckVechielItem>> GetItemsAsync(bool forceRefresh = false)
        {

            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"InspectVehicle");
                checkVechielItems = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CheckVechielItem>>(json));
            }
            return checkVechielItems;
        }
        public async Task<CheckVechielItem> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"InspectVehicle/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<CheckVechielItem>(json));
            }

            return null;
        }
        public async Task<bool> AddItemAsync(CheckVechielItem checkVechielItem)
        {
            if (checkVechielItem == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(checkVechielItem);

            var response = await client.PutAsync($"InspectVehicle", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateItemAsync(CheckVechielItem checkVechielItem)
        {
            if (checkVechielItem == null || checkVechielItem.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(checkVechielItem);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"{checkVechielItem.Id}"), byteContent);

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
