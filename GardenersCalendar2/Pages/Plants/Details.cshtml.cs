using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.Plants
{
    public class DetailsModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public DetailsModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Plant Plant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.Garden)
                .Include(p => p.Nursery)
                .FirstOrDefaultAsync(m => m.PlantId == id);
            if (plant == null)
            {
                return NotFound();
            }
            else 
            {
                Plant = plant;
            }
            return Page();
        }
    }
}
