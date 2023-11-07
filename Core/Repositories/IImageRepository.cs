using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Core.Repositories
{
    public interface IImageRepository
    {
        void AddAdvertImage(AdvertImagesViewModel adImgVM, string userId);

        void AddImage(Image image);

        void DeleteImage(int id, string userId);

        byte[] GetImage(int id, string userId);
    }
}
