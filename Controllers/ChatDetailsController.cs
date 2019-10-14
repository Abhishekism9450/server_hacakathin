using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

namespace api.Controllers
{
    //public class callFunctions
    //{
    //   public string Sfunction()
    //    {

    //        return "hey, custom";
    //    }
    //}
    [Route("api/[controller]")]
    [ApiController]
    public class ChatDetailsController : ControllerBase
    {

        private readonly ChatService _eventService;
        public ChatDetailsController(ChatService eventService)
        {
            _eventService = eventService;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        public ActionResult<List<ChatDetails>> Get() =>
          _eventService.Get();
        [EnableCors("AllowAllHeaders")]
        //[HttpGet("{id:length(24)}", Name = "GetEvents")]
        //public ActionResult<ChatDetails> Get(string id)
        //{
        //    var events = _eventService.Get(id);
        //    if (events == null)
        //    {
        //        return NotFound();
        //    }
        //    return events;//dfsdfsdfsdf
        //}

        [HttpGet]
        [Route("{id}", Name="GetEvents")]
        public ActionResult<List<ChatDetails>> Get(string id)
        {
            var Confessions = _eventService.GetByUser(id);
            if (Confessions == null)
            {
                return NotFound();
            }
            return Confessions;
        }


        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        public ActionResult<ChatDetails> Create(ChatDetails events)
        {
            _eventService.Create(events);
            return CreatedAtRoute("GetEvents", new { id = events.Id.ToString() }, events);
        }
        //public string Create()
        //{
        //    return callFunctions.Sfunction();
        //}

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, ChatDetails eventsIn)
        {
            var events = _eventService.Get(id);
            if (events == null)
            {
                return NotFound();
            }
            _eventService.Update(id, eventsIn);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var events = _eventService.Get(id);
            if (events == null)
            {
                return NotFound();
            }
            _eventService.Remove(events.Id);
            return NoContent();
        }
    }
}