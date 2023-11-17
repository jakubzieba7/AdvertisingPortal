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
    [AllowAnonymous]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;
        private readonly ICategoryService _categoryService;
        private GetAdvertsParams _getAdvertsParams;
        private readonly IConfiguration _config;

        public AdvertController(IAdvertService advertService, ICategoryService categoryService, IConfiguration config)
        {
            _config = config;
            _advertService = advertService;
            _categoryService = categoryService;
            _getAdvertsParams = new GetAdvertsParams()
            {
                Title = null,
                CategoryId = 0,
                BuySellCategoryId = 0,
                ItemServiceCategoryId = 0,
                PriceMin = 0,
                PriceMax = 0,
                IsFinished = false,
                IsPromoted = false

            };
        }
        public IActionResult Adverts()
        {
            _getAdvertsParams.UserId = User.GetUserId();
            ViewBag.UserID=User.GetUserId();

            var vm = new AdvertsViewModel()
            {
                Adverts = _advertService.GetAdverts(_getAdvertsParams),
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
                Heading = id == 0 ? "Dodawanie nowej oferty" : "Edycja oferty",
                Advert = advert,
                Categories = _categoryService.GetCategories(),
                BuySellCategories = _categoryService.GetBuySellCategories(),
                ItemServiceCategories = _categoryService.GetItemServiceCategories()
            };

            return View(vm);
        }

        public IActionResult AdvertReadOnly(int id)
        {
            
            var advert = _advertService.GetAdvertReadOnly(id);

            var vm = new AdvertViewModel()
            {
                Heading = $"Oferta nr {id}",
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
            var advertImage = new Image() { Id = imageId, AdvertId = advertId, UserId = userId };
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
            viewModel.FilterAdverts.GetAdvertsParams.UserId = User.GetUserId();

            var adverts = _advertService.GetAdverts(viewModel.FilterAdverts.GetAdvertsParams);

            return PartialView("_AdvertsTable", adverts);
        }

        public IActionResult AdvertsMap(GetAdvertsParams getAdvertsParams)
        {
            //_getAdvertsParams = getAdvertsParams;
            _getAdvertsParams.UserId = User.GetUserId();
            var adverts = _advertService.GetAdverts(_getAdvertsParams);
            ViewBag.googleMapsApiKey = _config["GoogleMapsAPI:APIKey"];

            return View(adverts);
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
