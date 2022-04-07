namespace ResourceManagement.Models
{
    public class AuditableEntity<TId> : IAuditableEntity<TId>
    {
        public DateTime CreateAt { get; set; }
        public TId Id { get; set; }
    }
}
