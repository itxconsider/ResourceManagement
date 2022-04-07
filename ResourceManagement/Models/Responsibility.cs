using System.ComponentModel.DataAnnotations;

namespace ResourceManagement.Models
{
    public class Responsibility : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
