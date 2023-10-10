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
    }
}
