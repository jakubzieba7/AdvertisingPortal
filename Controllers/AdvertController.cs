using AdvertisingPortal.Core.Models;
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
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;
        private readonly ICategoryService _categoryService;

        public AdvertController(IAdvertService advertService, ICategoryService categoryService)
        {
            _advertService = advertService;
            _categoryService= categoryService;
        }
        public IActionResult Adverts()
        {
            var userId = User.GetUserId();

            var vm = new AdvertsViewModel()
            {
                Adverts = _advertService.GetAdverts(userId),
                Categories = _categoryService.GetCategories(),
                ItemServiceCategories = _categoryService.GetItemServiceCategories(),
                BuySellCategories = _categoryService.GetBuySellCategories(),
                FilterAdverts = new FilterAdverts()
            };

            return View(vm);
        }

        public IActionResult Advert(int id = 0)
        {
            var userId = User.GetUserId();
            var advert = id == 0 ? new Advert { Id = 0, UserId = userId, AdvertDate = DateTime.Now } : _advertService.GetAdvert(id, userId);

            var vm = new AdvertViewModel()
            {
                Heading = id == 0 ? "Dodawanie nowego ogłoszenia" : "Edycja ogłoszenia",
                Advert = advert,
                Categories = _categoryService.GetCategories(),
                BuySellCategories = _categoryService.GetBuySellCategories(),
                ItemServiceCategories = _categoryService.GetItemServiceCategories()
            };

            return View(vm);
        }

        public IActionResult UploadImage(int advertId, int imageId = 0)
        {
            var userId = User.GetUserId();
            var advertImage = new Image() { Id = imageId, AdvertId = advertId, UserId=userId };
            var vm = new AdvertImagesViewModel() { Heading = "Nowe zdjęcia", Image = advertImage };

            return View("AdvertImageLoad", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Advert(Advert advert)
        {
            var userId = User.GetUserId();
            advert.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new AdvertViewModel
                {
                    Advert = advert,
                    Categories = _categoryService.GetCategories(),
                    BuySellCategories = _categoryService.GetBuySellCategories(),
                    ItemServiceCategories = _categoryService.GetItemServiceCategories(),
                    Heading = advert.Id == 0 ? "Dodawanie nowego ogłoszenia" : "Edytowanie ogłoszenia"
                };

                return View("Advert", vm);
            }

            if (advert.Id == 0)
                _advertService.Add(advert);
            else
                _advertService.Update(advert);

            return RedirectToAction("Adverts");
        }

        [HttpPost]
        public IActionResult Adverts(AdvertsViewModel viewModel)
        {
            var userId = User.GetUserId();

            var adverts = _advertService.GetAdverts(userId, viewModel.FilterAdverts.Title, viewModel.FilterAdverts.CategoryId, viewModel.FilterAdverts.BuySellCategoryId, viewModel.FilterAdverts.ItemServiceCategoryId, viewModel.FilterAdverts.PriceMin.Value, viewModel.FilterAdverts.PriceMax.Value, viewModel.FilterAdverts.IsFinished, viewModel.FilterAdverts.IsPromoted);

            return PartialView("_AdvertsTable", adverts);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _advertService.Delete(id, userId);
            }
            catch (Exception ex)
            {
                //logowanie do pliku
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

    }
}
