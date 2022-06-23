using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GardenersCalendar2.Data.GardenerUserNS;

namespace GardenersCalendar2.Pages.ToDos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;

        public IndexModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<ToDo> ToDo { get;set; } = default!;

        public async Task OnGetAsync(int? id, DateTime? dueDate)
        {
            if (_context.ToDos != null)
            {
                string loggedInUserId = _userManager.GetUserId(User);

                IQueryable<ToDo> toDos = _context.ToDos.Include(t => t.Plant).Where(t => t.GardenerUserId == loggedInUserId);
                if (id != null)
                {
                    toDos = toDos.Where(t => t.PlantId == id);
                }
                if (dueDate != null)
                {
                    toDos = toDos.Where(t => t.DueDate.Date == dueDate.Value.Date);
                }

                ToDo = await toDos.OrderBy(t => t.DueDate).ThenBy(t => t.Plant.Name).ToListAsync();

            }
        }
    }
}
