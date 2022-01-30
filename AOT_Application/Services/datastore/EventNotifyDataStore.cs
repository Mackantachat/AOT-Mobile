using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOT_Application.Services
{
    public interface EventNotifyDataStore<T>
    {
        Task<bool> AddItemAsync(T eventNotifyItem);
        Task<bool> UpdateItemAsync(T eventNotifyItem);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
