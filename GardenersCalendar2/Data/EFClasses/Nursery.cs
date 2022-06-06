namespace GardenersCalendar2.Data.EFClasses
{
    public class Nursery
    {
        public int NurseryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Plant>? Plants { get; set; }
    }
}
