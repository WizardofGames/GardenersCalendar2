namespace GardenersCalendar2.Data.EFClasses
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Job>? Tasks { get; set; }

        public int ParentList1Id { get; set; }
        public Nursery? ParentList1 { get; set; }
        public int ParentList2Id { get; set; }
        public Garden? ParentList2 { get; set; }
    }
}
