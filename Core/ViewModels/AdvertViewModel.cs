using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class AdvertViewModel
    {
        public string Heading { get; set; }
        public Advert Advert { get; set; }
        public IEnumerable<Advert> UserAdverts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BuySellCategory> BuySellCategories { get; set; }
        public IEnumerable<ItemServiceCategory> ItemServiceCategories { get; set; }
    }
}
