using AdvertisingPortal.Core.Repositories;
using AdvertisingPortal.Persistence.Repositories;

namespace AdvertisingPortal.Core
{
    public interface IUnitOfWork
    {
        IAdvertRepository Advert { get;}
        ICategoryRepository Category { get;}
        IImageRepository Image { get;}

        void Complete();
    }
}
