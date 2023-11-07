using AdvertisingPortal.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<BuySellCategory> GetBuySellCategories();

        IEnumerable<Category> GetCategories();

        IEnumerable<ItemServiceCategory> GetItemServiceCategories();
    }
}
