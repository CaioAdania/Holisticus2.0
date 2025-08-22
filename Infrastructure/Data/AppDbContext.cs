using Holisticus2._0.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Holisticus2._0.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
