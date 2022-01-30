using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOT_Application.Services
{
    public interface ExtingguisherDataStore<T>
    {
        Task<bool> AddItemAsync(T extingguisherItem);
        Task<bool> UpdateItemAsync(T extingguisherItem);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
