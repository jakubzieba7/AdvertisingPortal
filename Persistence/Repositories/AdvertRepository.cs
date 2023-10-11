﻿using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
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

        public IEnumerable<Advert> GetAdverts(string userId, string title = null, int categoryId = 0, int buySellCategoryId = 0, int itemServiceCategoryId = 0, bool IsFinished = false)
        {
            var adverts = _context.Adverts.
                Include(x => x.Category).
                Include(x => x.BuySellCategory).
                Include(x => x.ItemServiceCategory).
                Where(x => x.UserId == userId && x.IsFinished == IsFinished);

            if (buySellCategoryId == 1)
                adverts = adverts.Where(x => x.BuySellCategoryId == 1);
            else
                adverts = adverts.Where(x => x.BuySellCategoryId == 2);

            if (itemServiceCategoryId == 1)
                adverts = adverts.Where(x => x.ItemServiceCategoryId == 1);
            else
                adverts = adverts.Where(x => x.ItemServiceCategoryId == 2);

            if (categoryId != 0)
                adverts = adverts.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(title))
                adverts = adverts.Where(x => x.Title.Contains(title));

            return adverts.OrderBy(x => x.AdvertDate).ToList();
        }

        public Advert GetAdvert(int id, string userId)
        {
            return _context.Adverts.Single(x => x.Id == id && x.UserId == userId);
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

            _context.SaveChanges();
        }
    }
}
