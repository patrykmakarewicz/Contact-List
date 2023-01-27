using Microsoft.EntityFrameworkCore;
using ContactList.Shared;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ContactList.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Private" },
                new Category { Id = 2, CategoryName = "Business" },
                new Category { Id = 3, CategoryName = "Other" }
                );

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, FirstName = "Emergency Number", PhoneNumber="911", CategoryId=1 }
                );
        }
    }
}
