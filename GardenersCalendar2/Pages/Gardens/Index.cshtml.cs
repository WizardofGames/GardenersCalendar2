using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Identity;
using GardenersCalendar2.Data.GardenerUserNS;
using GardenersCalendar2.Services;

namespace GardenersCalendar2.Pages.Gardens
{
    public class IndexModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;
        private readonly FullCalendarService _calendar;
        public IndexModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager, FullCalendarService calendar)
        {
            _context = context;
            _userManager = userManager;
            _calendar = calendar;
        }

        public IList<Garden> Garden { get;set; } = default!;
        public List<ToDo> ToDos { get; private set; }
        public string JsonForCalendarEvents { get; private set; }

        public async Task OnGetAsync()
        {
            if (_context.Gardens != null)
            {
                string LoggedInUserId = _userManager.GetUserId(User);
                Garden = await _context.Gardens.Where(g => g.GardenerUserId == LoggedInUserId).ToListAsync();
            }

            List<ToDo> toDos = _context.ToDos.ToList();
            ToDos = toDos;
            JsonForCalendarEvents = _calendar.ConvertListOfToDosToJson(toDos);

        }
    }
}
