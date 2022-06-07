namespace GardenersCalendar2.Data.EFClasses
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<ToDo>? ToDo { get; set; }

        public int? NurseryId { get; set; }
        public Nursery? Nursery { get; set; }
        public int? GardenId { get; set; }
        public Garden? Garden { get; set; }
    }
}
