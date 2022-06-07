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
    public class DeleteModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public DeleteModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Garden Garden { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gardens == null)
            {
                return NotFound();
            }

            var garden = await _context.Gardens.FirstOrDefaultAsync(m => m.GardenId == id);

            if (garden == null)
            {
                return NotFound();
            }
            else 
            {
                Garden = garden;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Gardens == null)
            {
                return NotFound();
            }
            var garden = await _context.Gardens.FindAsync(id);

            if (garden != null)
            {
                Garden = garden;
                _context.Gardens.Remove(Garden);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
