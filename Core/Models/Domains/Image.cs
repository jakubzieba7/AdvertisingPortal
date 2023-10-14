namespace AdvertisingPortal.Core.Models.Domains
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public Advert Advert { get; set; }
        public int AdvertId { get; set; }
    }
}
