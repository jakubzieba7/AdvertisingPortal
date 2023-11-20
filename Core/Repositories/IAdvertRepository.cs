using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core.Repositories
{
    public interface IAdvertRepository
    {
        IEnumerable<Advert> GetAdverts(GetAdvertsParams getAdvertsParams);
        IEnumerable<Advert> GetAdvertsUser(int id);

        Advert GetAdvert(int id, string userId);
        Advert GetAdvertReadOnly(int id);

        void Add(Advert advert);

        void Update(Advert advert);

        void Delete(int id, string userId);
        
    }
}
