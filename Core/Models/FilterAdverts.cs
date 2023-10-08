using System.ComponentModel.DataAnnotations;

namespace AdvertisingPortal.Core.Models
{
    public class FilterAdverts
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int BuySellCategoryId { get; set; }
        public int ItemServiceCategoryId { get; set; }
        [Display(Name = "Tylko aktualne")]
        public bool IsExisting { get; set; }
    }
}
