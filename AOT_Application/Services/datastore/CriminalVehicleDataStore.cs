using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AOT_Application.Services
{
    public interface CriminalVehicleDataStore<T>
    {
        Task<bool> AddItemAsync(T criminalVehicleItem);
        Task<bool> UpdateItemAsync(T criminalVehicleItem);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
