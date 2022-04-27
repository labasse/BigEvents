namespace EventBack
{
    public class TagEntity
    {
        public string Title { get; set; } = null!;
        public DateTime Created { get; } = DateTime.Now;

        public override string ToString() => Title;
        public override bool Equals(object? obj) => 
            obj is TagEntity 
            && Title == obj.ToString();

        public override int GetHashCode() => 
            Title?.GetHashCode() ?? 0;
    }
}
