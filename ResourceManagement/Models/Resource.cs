namespace ResourceManagement.Models
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
        public virtual ICollection<Work> Workings { get; set; }
        public ICollection<WorkGroupResource> WorkGroupResources { get; set; }

    }
}
