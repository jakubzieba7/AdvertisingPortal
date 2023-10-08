using AdvertisingPortal.Core.Models;
using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class AdvertsViewModel
    {
        public IEnumerable<Advert> Adverts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BuySellCategory> BuySellCategories { get; set; }
        public IEnumerable<ItemServiceCategory> ItemServiceCategories { get; set; }
        public FilterAdverts FilterAdverts { get; set; }
    }
}
