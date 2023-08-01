using System.ComponentModel;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Models;
using TMS_API.Models.Dto;
using TMS_API.Repository;

namespace TMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();
            var dtoEvents = _mapper.Map<List<EventDto>>(events);

            return Ok(dtoEvents);

        }

        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var @e = await _eventRepository.GetById(id);

            if(@e == null)
            {
                return NotFound();
            }
            
            var eventDto = _mapper.Map<EventDto>(@e);

            return Ok(eventDto);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(eventPatch, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete] public async Task<ActionResult> Delete(long id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }

        /*
        [HttpPost]
        public async Task<ActionResult> Add(EventDto @eventDto)
        {
            var eventEntity = await _eventRepository.GetById(@eventDto.EventId);
            if (eventEntity == null)
            {
                return Forbid();
            }
            var addedEventDto = _mapper.Map<Event>(@eventDto);
            _eventRepository.Add(addedEventDto);
            return Ok(addedEventDto);
        }
        */
    }
}
