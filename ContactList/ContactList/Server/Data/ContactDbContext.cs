using Microsoft.EntityFrameworkCore;
using ContactList.Shared;

namespace ContactList.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
    }
}
