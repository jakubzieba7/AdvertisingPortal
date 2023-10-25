using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Advert
    {
        public Advert()
        {
            Images = new Collection<Image>();
        }

        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Pole tytuł jest wymagane.")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [MaxLength(250)]
        [Required(ErrorMessage = "Pole opis jest wymagane.")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pole kategoria jest wymagane.")]
        [Display(Name = "Kategoria 3")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Pole kategoria jest wymagane.")]
        [Display(Name = "Kategoria 1")]
        public int BuySellCategoryId { get; set; }
        [Required(ErrorMessage = "Pole kategoria jest wymagane.")]
        [Display(Name = "Kategoria 2")]
        public int ItemServiceCategoryId { get; set; }
        [Display(Name = "Zakończone")]
        public bool IsFinished { get; set; }
        [Display(Name = "Promowane")]
        public bool IsPromoted { get; set; }
        [Display(Name = "Data publikacji")]
        public DateTime AdvertDate { get; set; }
        public string UserId { get; set; }
        public BuySellCategory BuySellCategory { get; set; }
        public ItemServiceCategory ItemServiceCategory { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Pole cena jest wymagane.")]
        [Display(Name ="Cena")]
        public decimal Price { get; set; }
        public ICollection<Image> Images { get; set; }
        [Display(Name = "Lokalizacja")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Niewłaściwy kod pocztowy")]
        [Display(Name = "Kod pocztowy")]
        public string ZipCode { get; set; }
    }
}
