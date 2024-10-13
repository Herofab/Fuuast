using Microsoft.EntityFrameworkCore; // For DbContext and DbSet
using fuuast.Models.Auths; // Ensure this references your Users model

namespace fuuast.Models
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        // Use DbSet from Entity Framework Core
        public DbSet<Users> Users { get; set; }
        public DbSet<feestructure> feestructure { get; set; }
    }
}
