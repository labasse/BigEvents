namespace EventBack
{
    public class EventEntity
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Start { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public double Rating { get; set; }
        public IEnumerable<TagEntity> Tags { get; set; } = null!;
    }
}
