using Microsoft.EntityFrameworkCore;
using ResourceManagement.Models;

namespace ResourceManagement.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<WorkGroup> WorkGroups { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<WorkGroupResource> WorkGroupResources { get; set; }
        public DbSet<Work> Works { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            if (builder == null) return;

            builder.Entity<WorkGroupResource>()
                .HasKey(e => new { e.WorkGroupId, e.ResourceId });

            builder.Entity<WorkGroupResource>()
                .HasOne(e => e.WorkGroup)
                .WithMany(e => e.WorkGroupResources)
                .HasForeignKey(e=>e.WorkGroupId);

            builder.Entity<WorkGroupResource>()
               .HasOne(e => e.Resource)
               .WithMany(e => e.WorkGroupResources)
               .HasForeignKey(e => e.ResourceId);
        }
    }
}
