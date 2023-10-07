using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Adverts = new Collection<Advert>();
            BuySellCategories = new Collection<BuySellCategory>();
            ItemServiceCategories = new Collection<ItemServiceCategory>();
        }
        public int Id { get; set; }
        public int Lp { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Pole nazwa jest wymagane.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CategoryBuySellId { get; set; }
        public int CategoryItemServiceId { get; set; }
        public BuySellCategory CategoryBuySell { get; set; }
        public ItemServiceCategory CategoryItemService { get; set; }
        public ICollection<Advert> Adverts { get; set; }
        public ICollection<BuySellCategory> BuySellCategories { get; set; }
        public ICollection<ItemServiceCategory> ItemServiceCategories { get; set; }
    }
}