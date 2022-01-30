using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AOT_Application.Services
{
    public interface  CheckVehicleDataStore<T>
    {
        Task<bool> AddItemAsync(T checkVechielItem);
        Task<bool> UpdateItemAsync(T checkVechielItem);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
