using AdvertisingPortal.Persistence;
using AdvertisingPortal.Persistence.Extensions;
using AdvertisingPortal.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    public class MapController : Controller
    {
        private AdvertRepository _advertRepository;

        public MapController(ApplicationDbContext context)
        {
            _advertRepository = new AdvertRepository(context);
        }
        public IActionResult AdvertsMap()
        {
            var userId = User.GetUserId();
            var adverts = _advertRepository.GetAdverts(userId);

            return View(adverts);
            //return View();
        }
    }
}
