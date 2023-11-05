using AdvertisingPortal.Persistence;
using AdvertisingPortal.Persistence.Extensions;
using AdvertisingPortal.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    public class MapController : Controller
    {
        private AdvertRepository _advertRepository;
        private readonly IConfiguration _config;

        public MapController(ApplicationDbContext context, IConfiguration config)
        {
            _advertRepository = new AdvertRepository(context);
            _config = config;
        }
        public IActionResult AdvertsMap()
        {
            var userId = User.GetUserId();
            var adverts = _advertRepository.GetAdverts(userId);
            ViewBag.googleMapsApiKey = _config["GoogleMapsAPI:APIKey"];

            return View(adverts);
        }

    }
}
