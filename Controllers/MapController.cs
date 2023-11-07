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

        public MapController(IAdvertService advertiseService, IConfiguration config)
        {
            _advertiseService = advertiseService;
            _config = config;
        }
        public IActionResult AdvertsMap()
        {
            var userId = User.GetUserId();
            var adverts = _advertiseService.GetAdverts(userId);
            ViewBag.googleMapsApiKey = _config["GoogleMapsAPI:APIKey"];

            return View(adverts);
        }

    }
}
