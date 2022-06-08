using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.ToDos
{
    public class IndexModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public IndexModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDo> ToDo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ToDos != null)
            {
                ToDo = await _context.ToDos
                .Include(t => t.Plant).ToListAsync();
            }
        }
    }
}
