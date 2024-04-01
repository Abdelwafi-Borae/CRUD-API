using CRUD_Operation_Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation_Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<College>(s => s.college)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.College_Id);

        }


    }
    
}
