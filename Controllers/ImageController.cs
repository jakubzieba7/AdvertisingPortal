using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Services;
using AdvertisingPortal.Core.ViewModels;
using AdvertisingPortal.Persistence;
using AdvertisingPortal.Persistence.Extensions;
using AdvertisingPortal.Persistence.Repositories;
using AdvertisingPortal.Persistence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadImage(AdvertImagesViewModel imgVM)
        {
            var userId = User.GetUserId();

            foreach (var file in Request.Form.Files)
            {
                Image image = new Image();
                image.Name = file.FileName;
                image.AdvertId = imgVM.Image.AdvertId;
                image.UserId = userId;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                image.Data = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _imageService.AddImage(image);
            }

            return RedirectToAction("Advert", "Advert", new { id = imgVM.Image.AdvertId });
        }

        [HttpPost]
        public IActionResult DeleteImage(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _imageService.DeleteImage(id, userId);
            }
            catch (Exception ex)
            {
                //logowanie do pliku
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

        public IActionResult EnlargeShowcaseImage(int id)
        {
            var userId = User.GetUserId();
            var imageData = _imageService.GetImage(id, userId);

            try
            {
                return File(imageData, "image/png");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult _AdvertImagesTabel() 
        {
            return ViewBag.UserId= User.GetUserId();
        }
    }
}
