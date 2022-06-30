using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GardenersCalendar2.Pages.Plants
{
    public class DeleteMultipleModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public DeleteMultipleModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Plant> Plants { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public List<int> CheckCompleted { get;set; }

        public async Task OnGetAsync()
        {
            ViewData["CheckedSelectList"] = new SelectList(CheckCompleted);
            if (_context.ToDos != null)
            {
                Plants = await _context.Plants
                .Include(p => p.Garden)
                .Include(p => p.Nursery)
                .Where(p => CheckCompleted.Contains(p.PlantId))
                .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IQueryable<Plant> CheckedPlants = _context.Plants
                .Where(p => CheckCompleted.Contains(p.PlantId));
                _context.Plants.RemoveRange(CheckedPlants);
                await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
