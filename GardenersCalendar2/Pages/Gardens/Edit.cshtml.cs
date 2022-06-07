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

namespace GardenersCalendar2.Pages.Gardens
{
    public class EditModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public EditModel(GardenersCalendar2.Data.ApplicationDbContext context)
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

            var garden =  await _context.Gardens.FirstOrDefaultAsync(m => m.GardenId == id);
            if (garden == null)
            {
                return NotFound();
            }
            Garden = garden;
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

            _context.Attach(Garden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenExists(Garden.GardenId))
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

        private bool GardenExists(int id)
        {
          return (_context.Gardens?.Any(e => e.GardenId == id)).GetValueOrDefault();
        }
    }
}
