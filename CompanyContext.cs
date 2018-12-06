using Microsoft.EntityFrameworkCore;

namespace EfCoreValueObjects
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ValueObjectsEFCore22;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(
            c =>
            {
                c.HasKey("Id");
                c.Property(e => e.Name);
            });

            modelBuilder.Entity<Company>().OwnsMany<CompanyAddress>("Addresses", a =>
            {
                a.HasForeignKey("CompanyId");
                a.Property(ca => ca.City);
                a.Property(ca => ca.AddressLine1);
                a.HasKey("CompanyId", "City", "AddressLine1");
            });
        }
    }
}