using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    public class MapController : Controller
    {
        public IActionResult AdvertsMap()
        {
            return View();
        }
    }
}
