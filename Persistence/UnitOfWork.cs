using AdvertisingPortal.Persistence.Repositories;

namespace AdvertisingPortal.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Advert=new AdvertRepository(context);
            Category = new CategoryRepository(context);
            Image = new ImageRepository(context);
        }

        public AdvertRepository Advert { get; set; }
        public CategoryRepository Category { get; set; }
        public ImageRepository Image { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
