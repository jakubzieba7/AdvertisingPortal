using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models
{
    public class FilterAdverts
    {
        private decimal? _priceMin;
        private decimal? _priceMax;
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int BuySellCategoryId { get; set; }
        public int ItemServiceCategoryId { get; set; }
        [Display(Name = "Zakończone")]
        public bool IsFinished { get; set; }
        [Display(Name = "Promowane")]
        public bool IsPromoted { get; set; }
        [Display(Name = "Cena min")]
        public decimal? PriceMin
        {
            get
            {
                return _priceMin;
            }
            set
            {
                _priceMin = value.HasValue ? value.Value : 0;
            }
        }
        [Display(Name = "Cena max")]
        public decimal? PriceMax
        {
            get
            {
                return _priceMax;
            }
            set
            {
                _priceMax = value.HasValue ? value.Value : 0;
            }
        }
    }
}
