using ContactsControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsControl.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contact { get; set; }
    }
}