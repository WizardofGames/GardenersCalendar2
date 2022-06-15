using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using GardenersCalendar2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GardenersCalendar2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly FullCalendarService _calendar;
        public string JsonForCalendarEvents { get; set; }

        public IndexModel(ApplicationDbContext context, FullCalendarService calendar)
        {
            _context = context;
            _calendar = calendar;
        }

        public void OnGet()
        {
            List<ToDo> toDos = _context.ToDos.ToList();
            JsonForCalendarEvents = _calendar.ConvertListOfToDosToJson(toDos);
        }
    }
}