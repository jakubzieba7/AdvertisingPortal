using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Repositories
{
    public class ImageRepository
    {
        private ApplicationDbContext _context;
        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAdvertImage(AdvertImagesViewModel adImgVM, string userId)
        {
            var advertToAddImage = _context.Adverts.Single(x => x.Id == adImgVM.Advert.Id && x.UserId == userId);
        }

        public void AddImage(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public void DeleteImage(int id, string userId)
        {
            var imageToDelete = _context.Images.Single(x => x.Id == id);

            _context.Images.Remove(imageToDelete);
            _context.SaveChanges();
        }

        public byte[] GetImage(int id)
        {
            var imageData = _context.Images.Single(x => x.Id == id);

            return imageData.Data;
        }
    }
}
