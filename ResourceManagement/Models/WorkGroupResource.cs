namespace ResourceManagement.Models
{
    public class WorkGroupResource
    {
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }
        public Guid WorkGroupId { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}
