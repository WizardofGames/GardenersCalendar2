using GardenersCalendar2.Data.GardenerUserNS;

namespace GardenersCalendar2.Data.EFClasses
{
    public class Nursery
    {
        public string? GardenerUserId { get; set; } = default;
        public GardenerUserClass? GardenerUser { get; set; }
        public int NurseryId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<Plant>? Plants { get; set; }
    }
}
