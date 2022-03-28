namespace ResourceManagement.Models
{
    public class WorkGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<WorkGroupResource> WorkGroupResources { get; set; }

    }
}
