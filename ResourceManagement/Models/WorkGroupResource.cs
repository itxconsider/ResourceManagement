namespace ResourceManagement.Models
{
    public class WorkGroupResource
    {
        public string ResourceId { get; set; }
        public Resource Resource { get; set; }
        public string WorkGroupId { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}
