using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ApiTest1.Models;
using ApiTest1.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Default")]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService userService)
        {
            _eventService = userService;
        }

        // GET: api/Event
        [HttpPost("now")]
        [EnableCors("Default")]
  
        public ActionResult<List<Event>> Post([FromBody] EventRequest Request)
        {
            return _eventService.Get(Request.date);
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "GetEvent")]
        [EnableCors("Default")]
        public ActionResult<Event> Get(string id)
        {
            var ev = _eventService.Get(id);
            if (ev == null)
            {
                return NotFound();
            }

            return ev;
        }

        // POST: api/Event
        [HttpPost]
        [EnableCors("Default")]
        public ActionResult<Event> Create(Event ev)
        {
            _eventService.Create(ev);

            return CreatedAtRoute("GetEvent", new { id = ev.Id.ToString() }, ev);
        }
        // PUT: api/Event/5
        [HttpPut("{id}")]
        [EnableCors("Default")]
        public IActionResult Update(string id, Event evIn)
        {
            var ev = _eventService.Get(id);

            if (ev == null)
            {
                return NotFound();
            }
            _eventService.Update(id, evIn);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("Default")]
        public IActionResult Delete(string id, Event evIn)
        {
            var ev = _eventService.Get(id);

            if (ev == null)
            {
                return NotFound();
            }

            _eventService.Remove(evIn.Id);

            return NoContent();
        }
    }
}
