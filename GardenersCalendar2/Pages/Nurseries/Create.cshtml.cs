using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.Nurseries
{
    public class CreateModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public CreateModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Nursery Nursery { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Nurseries == null || Nursery == null)
            {
                return Page();
            }

            _context.Nurseries.Add(Nursery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
