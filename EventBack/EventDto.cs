namespace EventBack
{
    public class EventDto
    {
        public Guid? Id { get; set; }
        public DateTime Start { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string>? Tags { get; set; }

        public EventEntity ToEntity(IEventService service) => 
            CopyTo(service, new EventEntity());
        
        public EventEntity CopyTo(IEventService service, EventEntity entity)
        {
            entity.Id = Id ?? Guid.NewGuid();
            entity.Start = Start;
            entity.Title = Title;
            entity.Description = Description;
            entity.Rating = Rating;
            entity.Tags = Tags == null
                ? Array.Empty<TagEntity>()
                : service.TagsFromTitles(Tags);
            return entity;
        }
        public static EventDto FromEntity(EventEntity entity) =>
            new EventDto()
            {
                Id = entity.Id,
                Start = entity.Start,
                Title = entity.Title,
                Description = entity.Description,
                Rating = entity.Rating,
                Tags = entity.Tags.Select(tag => tag.Title)
            };
    }
}
