using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    public class GoogleMapAPIController : Controller
    {
        public IActionResult Map()
        {
            return View();
        }
    }
}
