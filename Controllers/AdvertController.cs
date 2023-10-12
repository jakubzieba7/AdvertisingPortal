﻿using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.ViewModels;
using AdvertisingPortal.Persistence;
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

        public AdvertController(ApplicationDbContext context)
        {
            _advertRepository = new AdvertRepository(context);
            _categoryRepository = new CategoryRepository(context);
        }
        public IActionResult Adverts()
        {
            var userId = User.GetUserId();

            var vm = new AdvertsViewModel()
            {
                Adverts = _advertRepository.GetAdverts(userId),
                Categories = _categoryRepository.GetCategories(),
                ItemServiceCategories = _categoryRepository.GetItemServiceCategories(),
                BuySellCategories = _categoryRepository.GetBuySellCategories(),
                FilterAdverts = new FilterAdverts()
            };

            return View(vm);
        }

        public IActionResult Advert(int id = 0)
        {
            var userId = User.GetUserId();
            var advert = id == 0 ? new Advert { Id = 0, UserId = userId, AdvertDate = DateTime.Now } : _advertRepository.GetAdvert(id, userId);

            var vm = new AdvertViewModel()
            {
                Heading = id == 0 ? "Dodawanie nowego ogłoszenia" : "Edycja ogłoszenia",
                Advert = advert,
                Categories = _categoryRepository.GetCategories(),
                BuySellCategories = _categoryRepository.GetBuySellCategories(),
                ItemServiceCategories = _categoryRepository.GetItemServiceCategories()
            };

            return View(vm);
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
                    Categories = _categoryRepository.GetCategories(),
                    BuySellCategories = _categoryRepository.GetBuySellCategories(),
                    ItemServiceCategories = _categoryRepository.GetItemServiceCategories(),
                    Heading = advert.Id == 0 ? "Dodawanie nowego ogłoszenia" : "Edytowanie ogłoszenia"
                };

                return View("Advert", vm);
            }

            if (advert.Id == 0)
                _advertRepository.Add(advert);
            else
                _advertRepository.Update(advert);

            return RedirectToAction("Adverts");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adverts(AdvertsViewModel viewModel)
        {
            var userId = User.GetUserId();

            var adverts = _advertRepository.GetAdverts(userId, viewModel.FilterAdverts.Title, viewModel.FilterAdverts.CategoryId, viewModel.FilterAdverts.BuySellCategoryId, viewModel.FilterAdverts.ItemServiceCategoryId, viewModel.FilterAdverts.IsFinished);

            return PartialView("_AdvertsTable", adverts);
        }
    }
}
