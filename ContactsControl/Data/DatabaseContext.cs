using ContactsControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsControl.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contact { get; set; }
    }
}