using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Adverts = new Collection<Advert>();
        }
        public int Id { get; set; }
        public int Lp { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Pole nazwa jest wymagane.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}