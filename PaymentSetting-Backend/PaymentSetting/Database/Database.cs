using Microsoft.EntityFrameworkCore;
using PaymentSetting.Models;

namespace PaymentSetting.Database
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions options) : base(options)
        {


        }

        // DbSet 

        public DbSet<Active> Actives { get; set; }
        public DbSet<Key> Keys { get; set; }
    }
}
