using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace AdvertisingPortal.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Adverts = new Collection<Advert>();
        }
        public ICollection<Advert> Adverts { get; set; }

    }

}
