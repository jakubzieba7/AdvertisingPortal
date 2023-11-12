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

        void AddCategory(Category category);

        void AddItemServiceCategory(ItemServiceCategory itemServiceCategory);

        void AddBuySellCategory(BuySellCategory buySellCategory);
    }
}
