using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qandr_api.DTO;
using qandr_api.Models;
using qandr_api.Repo;

namespace qandr_api.Services
{

    public class EventServices : IEvent
    {
        private readonly QandR_DBContext? _dbContext;
        public EventServices(QandR_DBContext? dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<string> CreateEvent(Event_DTO newEvent)
        {
            var anewEvent = new Event();
            anewEvent.Type = newEvent.Type;
            anewEvent.Description = newEvent.Description;
            anewEvent.Course_code = newEvent.Course_code;
            anewEvent.Created_at = DateTime.Now;
            anewEvent.Updated_at = DateTime.Now;
            anewEvent.StudentId = newEvent.StudentId;
            anewEvent.LecturerId = newEvent.LecturerId;
            anewEvent.Lecturer = newEvent.Lecturer;
            anewEvent.Student = newEvent.Student;

            var eve = await _dbContext!.Events.AddAsync(anewEvent);
            if (eve == null)
            {
                throw new Exception("Not Created");
            }

            await _dbContext!.Events.AddAsync(anewEvent);
            _dbContext.SaveChanges();
            return "New Event Created";
        }

        // public Task<Event> CreateEvent(Event newEvent)
        // {
        //     throw new NotImplementedException();
        // }


        public async Task<string> DeleteEvent(string id)
        {
            try
            {
                var events = await _dbContext!.Events.FindAsync(id);
                if (events == null)
                {
                    throw new Exception("No events found");
                }
                _dbContext!.Remove(events);
                return "Deleted Successfully";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            try
            {
                var events = await _dbContext!.Events.Include(e => e.Events).ToListAsync();
                if (events == null)
                {
                    return Enumerable.Empty<Event>();
                }
                return events!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                var errList = new List<Event>();
                return errList;
            }
        }

        public Task<Event> GetEvent(string id)
        {
            try
            {
                var events = _dbContext!.Events.Where(e => e.Id == id).Include(se => se.Events).FirstAsync();
                if (events == null)
                {
                    return null!;
                }
                return events!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                var err = new { ex.Message };
                return null!;
            }
        }

        public async Task<string> UpdateEvent(string id, Event_DTO newEvent)
        {
            try
            {
                var editEvent = await _dbContext!.Events.FindAsync(id);
                if (editEvent == null)
                {
                    return "null";
                }
                editEvent.Type = newEvent.Type;
                editEvent.Description = newEvent.Description;
                editEvent.Course_code = newEvent.Course_code;
                editEvent.Created_at = DateTime.Now;
                editEvent.Updated_at = DateTime.Now;
                editEvent.StudentId = newEvent.StudentId;
                editEvent.LecturerId = newEvent.LecturerId;
                editEvent.Lecturer = newEvent.Lecturer;
                editEvent.Student = newEvent.Student;

                _dbContext.Events.Attach(editEvent);
                _dbContext.SaveChanges();
                return "Updated";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "null!";
            }
        }
    }
}