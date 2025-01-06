using AplikasiMenejemenProduk.Data;
using AplikasiMenejemenProduk.Models;
using Microsoft.EntityFrameworkCore;

namespace AplikasiMenejemenProduk.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> SearchAsync(string? name, decimal? minPrice, decimal? maxPrice)
        {
            return await _context.Products
                .Where(p => (name == null || p.Name.Contains(name)) &&
                            (minPrice == null || p.Price >= minPrice) &&
                            (maxPrice == null || p.Price <= maxPrice))
                .ToListAsync();
        }

    }
}
