namespace ResourceManagement.Models
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<Resource> Resources { get; set; }

    }
}
