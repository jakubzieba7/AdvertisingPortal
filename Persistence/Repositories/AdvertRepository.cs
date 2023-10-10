using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class AdvertRepository
    {
        private ApplicationDbContext _context;
        public AdvertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Advert> GetAdverts(string userId)
        {
            return _context.Adverts.Where(x => x.UserId == userId).ToList();
        }

        public Advert GetAdvert(int id, string userId)
        {
            return _context.Adverts.Single(x => x.Id == id && x.UserId == userId);
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
            advertToUpdate.IsExisting = advert.IsExisting;
            advertToUpdate.IsPromoted = advert.IsPromoted;
        }
    }
}
