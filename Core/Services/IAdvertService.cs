using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Persistence;

namespace AdvertisingPortal.Core.Services
{
    public interface IAdvertService
    {
        IEnumerable<Advert> GetAdverts(GetAdvertsParams getAdvertsParams);

        Advert GetAdvert(int id, string userId);

        void Add(Advert advert);

        void Update(Advert advert);

        void Delete(int id, string userId);
    }
}
