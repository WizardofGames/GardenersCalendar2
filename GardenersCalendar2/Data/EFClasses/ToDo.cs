using System.ComponentModel.DataAnnotations;

namespace GardenersCalendar2.Data.EFClasses
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public int ParentListId { get; set; }
        public Plant? ParentList { get; set; }

       
    }
}
