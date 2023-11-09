using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Services;
using AdvertisingPortal.Persistence;
using AdvertisingPortal.Persistence.Extensions;
using AdvertisingPortal.Persistence.Repositories;
using AdvertisingPortal.Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    public class MapController : Controller
    {
        private readonly IAdvertService _advertiseService;
        private readonly IConfiguration _config;
        private readonly GetAdvertsParams _params;

        public MapController(IAdvertService advertiseService, IConfiguration config)
        {
            _advertiseService = advertiseService;
            _config = config;
            _params = new GetAdvertsParams()
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
        public IActionResult AdvertsMap()
        {
            _params.UserId = User.GetUserId();
            var adverts = _advertiseService.GetAdverts(_params);
            ViewBag.googleMapsApiKey = _config["GoogleMapsAPI:APIKey"];

            return View(adverts);
        }

    }
}
