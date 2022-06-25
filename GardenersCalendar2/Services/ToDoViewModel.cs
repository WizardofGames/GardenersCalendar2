using System.ComponentModel.DataAnnotations;

namespace GardenersCalendar2.Services
{
    public class ToDoViewModel
    {
        [Display(Name = "Plant")]
        public int PlantId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Recurrence Interval")]
        public int? RecurrenceInterval { get; set; }
    }
}
