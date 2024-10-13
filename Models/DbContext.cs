using Microsoft.EntityFrameworkCore; // For DbContext and DbSet
using fuuast.Models.Auths; // Ensure this references your Users model
using fuuast.Models;

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
        public DbSet<departments> department { get; set; }
        public DbSet<StudentsForm> StudentsForm { get; set; }
    }
}
