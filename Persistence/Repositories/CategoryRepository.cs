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
        internal IEnumerable<BuySellCategory> GetBuySellCategories()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<ItemServiceCategory> GetItemServiceCategories()
        {
            throw new NotImplementedException();
        }
    }
}
