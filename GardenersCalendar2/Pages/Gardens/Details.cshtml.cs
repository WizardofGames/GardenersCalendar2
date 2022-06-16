using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.Gardens
{
    public class DetailsModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        public List<ToDo> ToDoList { get; set; }

        public DetailsModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Garden Garden { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gardens == null)
            {
                return NotFound();
            }

            var garden = await _context.Gardens.Include(g => g.Plants).ThenInclude(p => p.ToDo).FirstOrDefaultAsync(m => m.GardenId == id);
            if (garden == null)
            {
                return NotFound();
            }
            else 
            {
                Garden = garden;
            }
            ToDoList = Garden.Plants.SelectMany(p => p.ToDo).ToList();
            return Page();
        }
    }
}
