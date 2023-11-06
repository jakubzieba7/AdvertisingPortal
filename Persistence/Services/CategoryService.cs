using AdvertisingPortal.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingPortal.Persistence.Services
{
    public class CategoryService
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryService(UnitOfWork unitOfWork)
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
    }
}
