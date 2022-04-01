using System.ComponentModel.DataAnnotations;

namespace ResourceManagement.Models
{
    public class Responsibility
    {
        [Key]
        public int Guid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
