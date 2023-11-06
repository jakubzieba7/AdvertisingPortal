using AdvertisingPortal.Persistence;
using AdvertisingPortal.Persistence.Extensions;
using AdvertisingPortal.Persistence.Repositories;
using AdvertisingPortal.Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    public class MapController : Controller
    {
        private AdvertService _advertiseService;
        private readonly IConfiguration _config;

        public MapController(ApplicationDbContext context, IConfiguration config)
        {
            _advertiseService = new AdvertService(new UnitOfWork(context));
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
