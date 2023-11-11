using AdvertisingPortal.Core;
using AdvertisingPortal.Core.Models.Domains;
using AdvertisingPortal.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BuySellCategory> GetBuySellCategories()
        {
            return _unitOfWork.Category.GetBuySellCategories();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Category.GetCategories();
        }

        public IEnumerable<ItemServiceCategory> GetItemServiceCategories()
        {
            return _unitOfWork.Category.GetItemServiceCategories();
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.Category.AddCategory(category);
            _unitOfWork.Complete();
        }

        public void AddItemServiceCategory(ItemServiceCategory itemServiceCategory)
        {
            _unitOfWork.Category.AddItemServiceCategory(itemServiceCategory);
            _unitOfWork.Complete();
        }

        public void AddBuySellCategory(BuySellCategory buySellCategory)
        {
            _unitOfWork.Category.AddBuySellCategory(buySellCategory);
            _unitOfWork.Complete();
        }
    }
}
