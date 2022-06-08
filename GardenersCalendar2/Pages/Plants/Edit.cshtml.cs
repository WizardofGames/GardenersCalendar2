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

namespace GardenersCalendar2.Pages.Plants
{
    public class EditModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public EditModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plant Plant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plant =  await _context.Plants.FirstOrDefaultAsync(m => m.PlantId == id);
            if (plant == null)
            {
                return NotFound();
            }
            Plant = plant;
           ViewData["NurseryId"] = new SelectList(_context.Nurseries, "NurseryId", "Name");
           ViewData["GardenId"] = new SelectList(_context.Gardens, "GardenId", "Name");
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

            _context.Attach(Plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(Plant.PlantId))
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

        private bool PlantExists(int id)
        {
          return (_context.Plants?.Any(e => e.PlantId == id)).GetValueOrDefault();
        }
    }
}
