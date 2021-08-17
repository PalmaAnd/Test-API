using Microsoft.EntityFrameworkCore;

namespace Test_API.Models
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documentitem>()
                .HasKey(x => x.Number);
        }

        public DbSet<Documentitem> Document { get; set; }
    }
}