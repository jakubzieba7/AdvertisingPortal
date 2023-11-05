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
        }

        public void DeleteImage(int id, string userId)
        {
            var imageToDelete = _context.Images.Single(x => x.Id == id && x.UserId==userId);

            _context.Images.Remove(imageToDelete);
        }

        public byte[] GetImage(int id, string userId)
        {
            var imageData = _context.Images.Single(x => x.Id == id && x.UserId == userId);

            return imageData.Data;
        }
    }
}
