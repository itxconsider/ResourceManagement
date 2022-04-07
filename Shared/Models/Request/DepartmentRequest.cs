namespace Shared.Models.Request
{
    public class DepartmentRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
