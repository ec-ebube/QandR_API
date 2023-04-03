using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.DTO;
using qandr_api.Models;

namespace qandr_api.Repo
{
    public interface IEvent
    {
        public Task<IEnumerable<Event>> GetEvents();
        public Task<Event> GetEvent(string id);
        public Task<string> UpdateEvent(string id, Event_DTO editEvent);
        
        public Task<string> CreateEvent(Event_DTO newEvent);
        // object CreateEvents(Event_DTO newEvent);
        public Task<string> DeleteEvent(string id);
    }
}