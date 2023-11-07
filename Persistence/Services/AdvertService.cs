using AdvertisingPortal.Core;
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

        public IEnumerable<Advert> GetAdverts(string userId, string title = null, int categoryId = 0, int buySellCategoryId = 0, int itemServiceCategoryId = 0, decimal priceMin = 0, decimal priceMax = 0, bool IsFinished = false, bool isPromoted = false)
        {
            return _unitOfWork.Advert.GetAdverts(userId, title, categoryId, buySellCategoryId, itemServiceCategoryId, priceMin, priceMax, IsFinished, isPromoted);
        }

        public Advert GetAdvert(int id, string userId)
        {
            return _unitOfWork.Advert.GetAdvert(id, userId);
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
