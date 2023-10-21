using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class AdvertRepository
    {
        private ApplicationDbContext _context;
        public AdvertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Advert> GetAdverts(string userId, string title = null, int categoryId = 0, int buySellCategoryId = 0, int itemServiceCategoryId = 0, decimal priceMin = 0, decimal priceMax = 0, bool IsFinished = false, bool isPromoted = false)
        {
            var adverts = _context.Adverts.
                Include(x=>x.Images).
                Include(x => x.Category).
                Include(x => x.BuySellCategory).
                Include(x => x.ItemServiceCategory).
                Where(x => x.UserId == userId && x.IsFinished == IsFinished);

            if (buySellCategoryId != 0)
                adverts = adverts.Where(x => x.BuySellCategoryId == buySellCategoryId);

            if (itemServiceCategoryId != 0)
                adverts = adverts.Where(x => x.ItemServiceCategoryId == itemServiceCategoryId);

            if (categoryId != 0)
                adverts = adverts.Where(x => x.CategoryId == categoryId);

            if (isPromoted)
                adverts = adverts.Where(x => x.IsPromoted == isPromoted);

            if (!string.IsNullOrWhiteSpace(title))
                adverts = adverts.Where(x => x.Title.Contains(title));

            if (priceMin != 0)
                adverts = adverts.Where(x => x.Price >= priceMin);

            if (priceMax != 0)
                adverts=adverts.Where(x => x.Price <= priceMax);

            return adverts.OrderBy(x => x.AdvertDate).ToList();
        }

        public Advert GetAdvert(int id, string userId)
        {
            return _context.Adverts.
                Include(x=>x.Images).
                Single(x => x.Id == id && x.UserId == userId);
        }

        public void Add(Advert advert)
        {
            _context.Adverts.Add(advert);
            _context.SaveChanges();
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

            _context.SaveChanges();
        }

        public void Delete(int id, string userId)
        {
            var advertToRemove = _context.Adverts.Single(x => x.Id == id && x.UserId == userId);

            _context.Adverts.Remove(advertToRemove);
            _context.SaveChanges();
        }

        
    }
}
