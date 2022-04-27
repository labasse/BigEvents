using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventMobileBasic
{
    public partial class EventApiService
    {
        public Task<EventDto> CreateEvent(EventDto body) 
            => EventsAsync(body);
        public Task<ICollection<EventDto>> GetEventsAsync()
            => EventsAllAsync();
        public Task UpdateEventAsync(Guid id, EventDto body) 
            => Events2Async(id, body);
        public Task DeleteEventAsync(Guid id)
            => Events3Async(id);

    }
}
