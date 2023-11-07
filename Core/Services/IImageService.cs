using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using AdvertisingPortal.Persistence;

namespace AdvertisingPortal.Core.Services
{
    public interface IImageService
    {
        void AddAdvertImage(AdvertImagesViewModel adImgVM, string userId);

        void AddImage(Image image);

        void DeleteImage(int id, string userId);

        byte[] GetImage(int id, string userId);
    }
}
