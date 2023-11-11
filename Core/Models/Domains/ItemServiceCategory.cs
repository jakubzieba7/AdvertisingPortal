using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class ItemServiceCategory
    {
        public ItemServiceCategory()
        {
            Adverts = new Collection<Advert>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}