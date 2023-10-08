using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using AdvertisingPortal.Persistence.Extensions;
using AdvertisingPortal.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdvertisingPortal.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        private AdvertRepository _advertRepository;
        private CategoryRepository _categoryRepository;

        public IActionResult Adverts()
        {
            var userId = User.GetUserId();

            var vm = new AdvertsViewModel()
            {
                Adverts = _advertRepository.GetAdverts(userId),
                Categories = _categoryRepository.GetCategories(),
                ItemServiceCategories = _categoryRepository.GetItemServiceCategories(),
                BuySellCategories = _categoryRepository.GetBuySellCategories()
            };

            return View(vm);
        }
    }
}
