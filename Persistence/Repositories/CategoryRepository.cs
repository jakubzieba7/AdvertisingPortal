using AdvertisingPortal.Core.Models.Domains;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class CategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BuySellCategory> GetBuySellCategories()
        {
            return _context.BuySellCategories.ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<ItemServiceCategory> GetItemServiceCategories()
        {
            return _context.ItemServiceCategories.ToList();
        }
    }
}
