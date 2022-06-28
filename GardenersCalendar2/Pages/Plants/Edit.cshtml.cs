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
using Microsoft.AspNetCore.Identity;
using GardenersCalendar2.Data.GardenerUserNS;

namespace GardenersCalendar2.Pages.Plants
{
    public class EditModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;

        public EditModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            PopulateDropDowns();
            return Page();
        }

        private void PopulateDropDowns()
        {
            string LoggedInUserId = _userManager.GetUserId(User);
            ViewData["NurseryId"] = new SelectList(_context.Nurseries.Where(n => n.GardenerUserId == LoggedInUserId), "NurseryId", "Name");
            ViewData["GardenId"] = new SelectList(_context.Gardens.Where(g => g.GardenerUserId == LoggedInUserId), "GardenId", "Name");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDowns();
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

            if (Plant.GardenId != null)
            {
                return RedirectToPage("/Gardens/Details", new {id=this.Plant.GardenId});
            }

            else
            {
                return RedirectToPage("/Nurseries/Details", new {id=this.Plant.NurseryId});
            }
            
        }

        private bool PlantExists(int id)
        {
          return (_context.Plants?.Any(e => e.PlantId == id)).GetValueOrDefault();
        }
    }
}
