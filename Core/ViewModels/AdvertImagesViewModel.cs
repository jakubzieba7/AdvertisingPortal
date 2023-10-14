using AdvertisingPortal.Core.Models.Domains;

namespace AdvertisingPortal.Core.ViewModels
{
    public class AdvertImagesViewModel
    {
        public Image Image { get; set; }
        public ICollection<Image> Images { get; set; }
        public string Heading { get; set; }
        public Advert Advert { get; set; }
    }
}
