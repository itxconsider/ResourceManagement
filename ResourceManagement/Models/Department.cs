using ResourceManagement.Contracts;

namespace ResourceManagement.Models
{
    public class Department : AuditableEntity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
