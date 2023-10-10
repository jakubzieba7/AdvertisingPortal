using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class Advert
    {
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
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        public int BuySellCategoryId { get; set; }
        public int ItemServiceCategoryId { get; set; }
        [Display(Name = "Zrealizowane")]
        public bool IsExisting { get; set; }
        public bool IsPromoted { get; set; }
        [Display(Name = "Termin")]
        public DateTime AdvertDate { get; set; }
        public string UserId { get; set; }
        public BuySellCategory BuySellCategory { get; set; }
        public ItemServiceCategory ItemServiceCategory { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}
