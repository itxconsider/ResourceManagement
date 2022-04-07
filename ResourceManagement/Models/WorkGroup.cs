using ResourceManagement.Contracts;

namespace ResourceManagement.Models
{
    public class WorkGroup : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<WorkGroupResource> WorkGroupResources { get; set; }

    }
}
