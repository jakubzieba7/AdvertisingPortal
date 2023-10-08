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

        internal IEnumerable<Advert> GetAdverts(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
