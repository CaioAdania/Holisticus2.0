using Holisticus2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Holisticus2._0.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Medicament> Medicament { get; set; }
    }
}
