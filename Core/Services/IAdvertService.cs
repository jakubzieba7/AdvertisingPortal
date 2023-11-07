using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Persistence;

namespace AdvertisingPortal.Core.Services
{
    public interface IAdvertService
    {
        IEnumerable<Advert> GetAdverts(string userId, string title = null, int categoryId = 0, int buySellCategoryId = 0, int itemServiceCategoryId = 0, decimal priceMin = 0, decimal priceMax = 0, bool IsFinished = false, bool isPromoted = false);

        Advert GetAdvert(int id, string userId);

        void Add(Advert advert);

        void Update(Advert advert);

        void Delete(int id, string userId);
    }
}
