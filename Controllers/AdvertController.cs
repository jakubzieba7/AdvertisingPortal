using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        public IActionResult Adverts()
        {
            var vm = new AdvertsViewModel()
            {
                Categories = new List<Category>() 
                { 
                    new Category() { Id = 1, Name = "Rowery" },
                    new Category() { Id = 2, Name = "Samochody" }
                },
                ItemServiceCategories = new List<ItemServiceCategory>()
                {
                    new ItemServiceCategory()
                    {
                        Id=1,Name="Rzecz"} ,
                    new ItemServiceCategory()
                    {
                        Id=2,Name="Usługa"}
                    },
                BuySellCategories = new List<BuySellCategory>()
                {
                    new BuySellCategory()
                    {Id=1,Name="Kupię" },
                    new BuySellCategory()
                    { Id=1,Name="Sprzedam"}
                }
            };

            return View(vm);
        }
    }
}
