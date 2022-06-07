using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.Nurseries
{
    public class EditModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public EditModel(GardenersCalendar2.Data.ApplicationDbContext context)
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

            var nursery =  await _context.Nurseries.FirstOrDefaultAsync(m => m.NurseryId == id);
            if (nursery == null)
            {
                return NotFound();
            }
            Nursery = nursery;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nursery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseryExists(Nursery.NurseryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NurseryExists(int id)
        {
          return (_context.Nurseries?.Any(e => e.NurseryId == id)).GetValueOrDefault();
        }
    }
}
