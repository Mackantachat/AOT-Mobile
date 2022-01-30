using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOT_Application.Services
{
    public interface CPDataStore<T>
    {
        Task<bool> AddItemAsync(T criminalPersonItem);
        Task<bool> UpdateItemAsync(T criminalPersonItem);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
