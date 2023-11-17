using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Services
{
    public class AdvertService: IAdvertService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdvertService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Advert> GetAdverts(GetAdvertsParams getAdvertsParams)
        {
            return _unitOfWork.Advert.GetAdverts(getAdvertsParams);
        }

        public Advert GetAdvert(int id, string userId)
        {
            return _unitOfWork.Advert.GetAdvert(id, userId);
        }

        public Advert GetAdvertReadOnly(int id)
        {
            return _unitOfWork.Advert.GetAdvertReadOnly(id);
        }

        public void Add(Advert advert)
        {
            _unitOfWork.Advert.Add(advert);
            _unitOfWork.Complete();
        }

        public void Update(Advert advert)
        {
            _unitOfWork.Advert.Update(advert);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Advert.Delete(id, userId);
            _unitOfWork.Complete();
        }
    }
}
