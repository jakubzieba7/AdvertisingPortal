using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Services;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Services
{
    public class ImageService: IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAdvertImage(AdvertImagesViewModel adImgVM, string userId)
        {
            _unitOfWork.Image.AddAdvertImage(adImgVM, userId);
        }

        public void AddImage(Image image)
        {
            _unitOfWork.Image.AddImage(image);
            _unitOfWork.Complete();
        }

        public void DeleteImage(int id, string userId)
        {
            _unitOfWork.Image.DeleteImage(id, userId);
            _unitOfWork.Complete();
        }

        public byte[] GetImage(int id, string userId)
        {
            return _unitOfWork.Image.GetImage(id, userId);
        }
    }
}
