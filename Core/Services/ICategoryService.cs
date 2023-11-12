using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<BuySellCategory> GetBuySellCategories();

        IEnumerable<Category> GetCategories();

        IEnumerable<ItemServiceCategory> GetItemServiceCategories();

        void AddCategory(Category category);

        void AddItemServiceCategory(ItemServiceCategory itemServiceCategory);

        void AddBuySellCategory(BuySellCategory buySellCategory);

    }
}
