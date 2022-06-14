namespace GardenersCalendar2.Data.EFClasses
{
    public class ToDoTemplate
    {
        public int ToDoTemplateId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int DayNumber { get; set; }

    }
}
