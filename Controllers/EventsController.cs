using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using qandr_api.DTO;
using qandr_api.Repo;

namespace qandr_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEvent? _ievent;
        public EventsController(IEvent ievent)
        {
            _ievent = ievent;
        }

        [HttpGet]
        public ActionResult getAllEvents()
        {
            var events = _ievent!.GetEvents();
            return Ok(events);
        }

        [HttpGet("/getEvent/{id}")]
        public ActionResult SingleEvent([FromRoute] string Id)
        {
            var singleEvent = _ievent!.GetEvent(Id);
            return Ok(singleEvent);
        }

        [HttpPost]
        public ActionResult createEvent([FromBody] Event_DTO newEvent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var events = _ievent!.CreateEvent(newEvent);
                    return Ok(events);

                }
                return BadRequest("Please fill all required feild");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/updateEvent/{id}")]
        public ActionResult updateEvent([FromBody] Event_DTO newEvent, [FromRoute] string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var events = _ievent!.UpdateEvent(id, newEvent);
                    return Ok(events);

                }
                return BadRequest("Please fill all required feild");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/{id}/deleteEvent")]
        public ActionResult deleteEvent([FromRoute] string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var events = _ievent!.DeleteEvent(id);
                    return Ok("Deleted");
                }
                return BadRequest("Couldn't find a matching id");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}