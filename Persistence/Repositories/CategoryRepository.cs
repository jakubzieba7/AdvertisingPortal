using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IApplicationDBContext _context;
        public CategoryRepository(IApplicationDBContext context)
        {
            _context = context;
        }
        public IEnumerable<BuySellCategory> GetBuySellCategories()
        {
            return _context.BuySellCategories.ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<ItemServiceCategory> GetItemServiceCategories()
        {
            return _context.ItemServiceCategories.ToList();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void AddItemServiceCategory(ItemServiceCategory itemServiceCategory)
        {
            _context.ItemServiceCategories.Add(itemServiceCategory);
        }

        public void AddBuySellCategory(BuySellCategory buySellCategory)
        {
            _context.BuySellCategories.Add(buySellCategory);
        }
    }
}
