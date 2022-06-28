using GardenersCalendar2.Data.EFClasses;
using GardenersCalendar2.Data.GardenerUserNS;
using GardenersCalendar2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GardenersCalendar2.Pages.MasterCalendar
{
    public class MasterCalendarModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        /*copy this one*/
        private readonly UserManager<GardenerUserClass> _userManager;
        private readonly FullCalendarService _calendar;

        public MasterCalendarModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager, FullCalendarService calendar)
        {
            _context = context;
            /*copy this one*/
            _userManager = userManager;
            _calendar = calendar;
        }

        public IList<Garden> Garden { get; set; } = default!;
        public List<ToDo> ToDos { get; private set; }
        public string JsonForCalendarEvents { get; private set; }


        public async Task OnGetAsync()
        {
            if (_context.Gardens != null)
            {
                string LoggedInUserId = _userManager.GetUserId(User);
                Garden = await _context.Gardens.Where(g => g.GardenerUserId == LoggedInUserId).ToListAsync();
            }

            /*and this*/
            List<ToDo> toDos = _context.ToDos.Include(t => t.Plant).Where(t => t.GardenerUserId == _userManager.GetUserId(User)).ToList();
            ToDos = toDos;
            JsonForCalendarEvents = _calendar.ConvertListOfToDosToJson(toDos);

        }
    }
}