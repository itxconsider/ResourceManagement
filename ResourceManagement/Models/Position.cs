namespace ResourceManagement.Models
{
    public class Position : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Resource> Resources { get; set; }

    }
}
