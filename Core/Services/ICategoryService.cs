using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<BuySellCategory> GetBuySellCategories();

        IEnumerable<Category> GetCategories();

        public IEnumerable<ItemServiceCategory> GetItemServiceCategories();

        public void AddCategory(Category category);

        public void AddItemServiceCategory(ItemServiceCategory itemServiceCategory);

        public void AddBuySellCategory(BuySellCategory buySellCategory);

    }
}
