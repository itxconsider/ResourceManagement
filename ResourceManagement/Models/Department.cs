﻿namespace ResourceManagement.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
    }
}