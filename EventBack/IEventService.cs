namespace EventBack
{
    public interface IEventService
    {
        IEnumerable<EventEntity> AllEvents { get; }
        IEnumerable<TagEntity> AllTags { get; }
        void AddTags(params string[] tagTitles);
        void AddEvent(EventEntity e);
        void RemoveById(Guid id);
        IEnumerable<TagEntity> TagsFromTitles(IEnumerable<string> titles);
    }
}
