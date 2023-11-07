using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Persistence;

namespace AdvertisingPortal.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<BuySellCategory> GetBuySellCategories();

        IEnumerable<Category> GetCategories();

        public IEnumerable<ItemServiceCategory> GetItemServiceCategories();
    }
}
