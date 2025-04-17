using Microsoft.EntityFrameworkCore;
using StaffSkill.Core.Model;

namespace StaffSkill
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
                .HasOne(s => s.Person)
                .WithMany(p => p.Skills)
                .HasForeignKey(s => s.PersonId);
        }
    }
}
