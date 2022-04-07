namespace ResourceManagement.Models
{
    public interface IAuditableEntity<TId> : IAuditableEntity, IEntity<TId>
    {
    }
    public interface IAuditableEntity : IEntity
    {
        public DateTime CreateAt { get; set; }
    }
}
