using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using AdvertisingPortal.Persistence;
using AdvertisingPortal.Persistence.Extensions;
using AdvertisingPortal.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private ImageRepository _imageRepository;

        public ImageController(ApplicationDbContext context)
        {
            _imageRepository = new ImageRepository(context);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadImage(AdvertImagesViewModel imgVM)
        {

            foreach (var file in Request.Form.Files)
            {
                Image image = new Image();
                image.Name = file.FileName;
                image.AdvertId = imgVM.Image.AdvertId;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                image.Data = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _imageRepository.AddImage(image);
            }

            return RedirectToAction("Advert", new { id = imgVM.Image.AdvertId });
        }

        [HttpPost]
        public IActionResult DeleteImage(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _imageRepository.DeleteImage(id, userId);
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
            var imageData = _imageRepository.GetImage(id);

            try
            {
                return File(imageData, "image/png");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
