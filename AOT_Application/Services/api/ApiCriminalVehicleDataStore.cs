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
    public class ApiCriminalVehicleDataStore : CriminalVehicleDataStore<CriminalVehicleItem>
    {
        HttpClient client;
        IEnumerable<CriminalVehicleItem> criminalvehicleitems;

        public ApiCriminalVehicleDataStore()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri($"{App.AzureBackendUrl}");

            criminalvehicleitems = new List<CriminalVehicleItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<CriminalVehicleItem>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"ViolationVihicle");
                criminalvehicleitems = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CriminalVehicleItem>>(json));
            }
            return criminalvehicleitems;
        }

        public async Task<CriminalVehicleItem> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"ViolationVihicle/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<CriminalVehicleItem>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(CriminalVehicleItem item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"ViolationVihicle", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(CriminalVehicleItem criminalVehicleItem)
        {
            if (criminalVehicleItem == null || criminalVehicleItem.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(criminalVehicleItem);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"ViolationVihicle/{criminalVehicleItem.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"ViolationVihicle/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
