namespace ResourceManagement.Contracts
{
    public interface IEntityWithExtendedAttributes<TExtendedAttribute>
    {
        public ICollection<TExtendedAttribute> ExtendedAttributes { get; set; }
    }
}