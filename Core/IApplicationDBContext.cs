using AdvertisingPortal.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core
{
    public interface IApplicationDBContext
    {
        DbSet<Advert> Adverts { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<BuySellCategory> BuySellCategories { get; set; }
        DbSet<ItemServiceCategory> ItemServiceCategories { get; set; }
        int SaveChanges();
    }
}
