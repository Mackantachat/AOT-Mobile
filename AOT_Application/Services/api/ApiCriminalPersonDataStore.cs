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
    public class ApiCriminalPersonDataStore : CPDataStore<CriminalPersonItem>
    {
        HttpClient client;
        IEnumerable<CriminalPersonItem> criminalpersonitems;

        public ApiCriminalPersonDataStore()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri($"{App.AzureBackendUrl}");

            criminalpersonitems = new List<CriminalPersonItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<CriminalPersonItem>> GetItemsAsync(bool forceRefresh = false)
        {
            //if (forceRefresh && IsConnected)
            //{
            //    var response = await client.GetAsync($"Person");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var content = await response.Content.ReadAsStringAsync();
            //        criminalpersonitems = JsonConvert.DeserializeObject<List<CriminalPersonItem>>(content);
            //    }
            //}
            //return criminalpersonitems;

            if (forceRefresh && IsConnected)
            {
                    var json = await client.GetStringAsync($"ViolationPerson");
                    criminalpersonitems = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CriminalPersonItem>>(json));
            }
            return criminalpersonitems;
        }

        public async Task<CriminalPersonItem> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"ViolationPerson/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<CriminalPersonItem>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(CriminalPersonItem criminalPersonItem)
        {
            if (criminalPersonItem == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(criminalPersonItem);

            var response = await client.PutAsync($"ViolationPerson", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(CriminalPersonItem criminalPersonItem)
        {
            if (criminalPersonItem == null || criminalPersonItem.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(criminalPersonItem);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"{criminalPersonItem.Id}"), byteContent);

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
