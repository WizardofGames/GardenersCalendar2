using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.Nurseries
{
    public class DeleteModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public DeleteModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Nursery Nursery { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nurseries == null)
            {
                return NotFound();
            }

            var nursery = await _context.Nurseries.FirstOrDefaultAsync(m => m.NurseryId == id);

            if (nursery == null)
            {
                return NotFound();
            }
            else 
            {
                Nursery = nursery;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Nurseries == null)
            {
                return NotFound();
            }
            var nursery = await _context.Nurseries.FindAsync(id);

            if (nursery != null)
            {
                Nursery = nursery;
                _context.Nurseries.Remove(Nursery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
