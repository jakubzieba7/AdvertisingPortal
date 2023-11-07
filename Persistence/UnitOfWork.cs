using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Repositories;
using AdvertisingPortal.Persistence.Repositories;

namespace AdvertisingPortal.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IApplicationDBContext _context;

        public UnitOfWork(IApplicationDBContext context)
        {
            _context = context;
            Advert=new AdvertRepository(context);
            Category = new CategoryRepository(context);
            Image = new ImageRepository(context);
        }

        public IAdvertRepository Advert { get; set; }
        public ICategoryRepository Category { get; set; }
        public IImageRepository Image { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
