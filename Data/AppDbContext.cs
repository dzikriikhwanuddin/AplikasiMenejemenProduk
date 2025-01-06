using Microsoft.EntityFrameworkCore;
using AplikasiMenejemenProduk.Models;

namespace AplikasiMenejemenProduk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
