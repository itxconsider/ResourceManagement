using ResourceManagement.Contracts;

namespace ResourceManagement.Models
{
    public class Work : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }
        public string Description { get; set; }
        public string ResourceId { get; set; }
        public Resource Resource { get; set; }
        public string WorkGroupId { get; set; }
        public WorkGroup WorkGroup { get; set; }
        public string ResponsibilityId { get; set; }
        public Responsibility Responsibility { get; set; }
    }
}
