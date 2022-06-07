using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Identity;

namespace GardenersCalendar2.Data.GardenerUserNS
{
    public class GardenerUserClass : IdentityUser
    {
        public List<Nursery>? Nurseries { get; set; }
        public List<Garden>? Gardens { get; set; }
    }
}
