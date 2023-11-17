using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using AdvertisingPortal.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IApplicationDBContext _context;
        public AdvertRepository(IApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Advert> GetAdverts(GetAdvertsParams getAdvertsParams)
        {
            var adverts = _context.Adverts.
                    Include(x => x.Images).
                    Include(x => x.Category).
                    Include(x => x.BuySellCategory).
                    Include(x => x.ItemServiceCategory).
                    Where(x => x.IsFinished == getAdvertsParams.IsFinished);

            if (getAdvertsParams.UserId is not null)
                adverts = adverts.Where(x => x.UserId == getAdvertsParams.UserId);

            if (getAdvertsParams.BuySellCategoryId != 0)
                adverts = adverts.Where(x => x.BuySellCategoryId == getAdvertsParams.BuySellCategoryId);

            if (getAdvertsParams.ItemServiceCategoryId != 0)
                adverts = adverts.Where(x => x.ItemServiceCategoryId == getAdvertsParams.ItemServiceCategoryId);

            if (getAdvertsParams.CategoryId != 0)
                adverts = adverts.Where(x => x.CategoryId == getAdvertsParams.CategoryId);

            if (getAdvertsParams.IsPromoted)
                adverts = adverts.Where(x => x.IsPromoted == getAdvertsParams.IsPromoted);

            if (!string.IsNullOrWhiteSpace(getAdvertsParams.Title))
                adverts = adverts.Where(x => x.Title.Contains(getAdvertsParams.Title));

            if (getAdvertsParams.PriceMin != 0)
                adverts = adverts.Where(x => x.Price >= getAdvertsParams.PriceMin);

            if (getAdvertsParams.PriceMax != 0)
                adverts = adverts.Where(x => x.Price <= getAdvertsParams.PriceMax);

            return adverts.OrderBy(x => x.AdvertDate).ToList();
        }

        public Advert GetAdvert(int id, string userId)
        {
            return _context.Adverts.
                Include(x => x.Images).
                Single(x => x.Id == id && x.UserId == userId);
        }

        public Advert GetAdvertReadOnly(int id)
        {
            return _context.Adverts.
                Include(x => x.Images).
                Single(x => x.Id == id);
        }

        public void Add(Advert advert)
        {
            _context.Adverts.Add(advert);
        }

        public void Update(Advert advert)
        {
            var advertToUpdate = _context.Adverts.Single(x => x.Id == advert.Id && x.UserId == advert.UserId);

            advertToUpdate.Title = advert.Title;
            advertToUpdate.Description = advert.Description;
            advertToUpdate.ItemServiceCategoryId = advert.ItemServiceCategoryId;
            advertToUpdate.BuySellCategoryId = advert.BuySellCategoryId;
            advertToUpdate.CategoryId = advert.CategoryId;
            advertToUpdate.IsFinished = advert.IsFinished;
            advertToUpdate.IsPromoted = advert.IsPromoted;
            advertToUpdate.Price = advert.Price;
            advertToUpdate.Location = advert.Location;
            advertToUpdate.ZipCode = advert.ZipCode;
        }

        public void Delete(int id, string userId)
        {
            var advertToRemove = _context.Adverts.Single(x => x.Id == id && x.UserId == userId);

            _context.Adverts.Remove(advertToRemove);
        }


    }
}
