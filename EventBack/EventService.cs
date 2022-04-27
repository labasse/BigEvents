namespace EventBack
{
    public class EventService : IEventService
    {
        private List<EventEntity> events = new ();
        private HashSet<TagEntity> tags = new ();
        public IEnumerable<EventEntity> AllEvents => events;
        public IEnumerable<TagEntity> AllTags => tags;

        public void AddTags(params string [] tagTitles)
        {
            foreach(var tag in tagTitles)
            {
                tags.Add(new TagEntity() { Title = tag });
            }
        }

        public void AddEvent(EventEntity e)
        {
            events.Add(e);
        }
        public void RemoveById(Guid id)
        {
            var e = events.FirstOrDefault(e => e.Id == id);

            if(e == null)
            {
                throw new ArgumentException("No event with this id");
            }
            events.Remove(e);
        }
        public IEnumerable<TagEntity> TagsFromTitles(IEnumerable<string> titles)
        {
            foreach(string title in titles)
            {
                var found = tags.FirstOrDefault(tags => tags.Title == title);

                if(found == null)
                {
                    throw new ArgumentException("Tag not found");
                }
                yield return found;
            }
        }

    }
}
