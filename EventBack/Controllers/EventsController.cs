using Microsoft.AspNetCore.Mvc;

namespace EventBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _events;

        public EventsController(IEventService events)
        {
            _events = events;
        }

        [HttpGet]
        public IEnumerable<EventDto> GetEvents()
        {
            return _events.AllEvents.Select(e => EventDto.FromEntity(e));
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventDto newEvent)
        {
            try
            {
                var entity = newEvent.ToEntity(_events);

                _events.AddEvent(entity);
                return Created($"events/{entity.Id}", EventDto.FromEntity(entity));
            }
            catch(ArgumentException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateEvent(Guid id, [FromBody] EventDto updatedEvent)
        {
            var entity = _events.AllEvents.FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                return NotFound("No event with this id");
            }
            try
            {
                updatedEvent.CopyTo(_events, entity);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEvent(Guid id)
        {
            try
            {
                _events.RemoveById(id);
                return NoContent();
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}