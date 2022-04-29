using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMobileMvvm.Services
{
    public class MockDataStore : IDataStore<EventDto>
    {
        private readonly List<EventDto> items;
        private readonly EventApiService api;
        public MockDataStore(EventApiService apiService)
        {
            api = apiService;
        }

        public async Task<bool> AddItemAsync(EventDto item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(EventDto item)
        {
            var oldItem = items.Where(arg => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where(arg => arg.Id?.ToString() == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<EventDto> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id?.ToString() == id));
        }

        public async Task<IEnumerable<EventDto>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}