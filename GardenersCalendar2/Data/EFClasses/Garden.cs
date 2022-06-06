namespace GardenersCalendar2.Data.EFClasses
{
    public class Garden
    {
        public int GardenId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Plant>? Plants { get; set; }
    }
}
