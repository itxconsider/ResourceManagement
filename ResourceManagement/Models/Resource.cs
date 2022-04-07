using ResourceManagement.Contracts;

namespace ResourceManagement.Models
{
    public class Resource : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
        public virtual ICollection<Work> Workings { get; set; }
        public ICollection<WorkGroupResource> WorkGroupResources { get; set; }

    }
}
