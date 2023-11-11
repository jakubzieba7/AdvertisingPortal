using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<BuySellCategory> GetBuySellCategories();

        IEnumerable<Category> GetCategories();

        IEnumerable<ItemServiceCategory> GetItemServiceCategories();

        public void AddCategory(Category category);

        public void AddItemServiceCategory(ItemServiceCategory itemServiceCategory);

        public void AddBuySellCategory(BuySellCategory buySellCategory);
    }
}
