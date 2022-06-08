using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.Plants
{
    public class CreateModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public enum ParentIdType
        {
            None, Nursery, Garden
        }
        public CreateModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult OnGet(int? nurseryOrGardenId, ParentIdType parentIdType)
        {
            PopulateDropDowns();

            Plant = new Plant();

            if (nurseryOrGardenId == null)
            {

            }

            else if (parentIdType == ParentIdType.Nursery)
            {
                Plant.NurseryId = nurseryOrGardenId;
            }

            else if (parentIdType == ParentIdType.Garden)
            {
                Plant.GardenId = nurseryOrGardenId;
            }

            return Page();
        }

        private void PopulateDropDowns()
        {
            ViewData["ParentList1Id"] = new SelectList(_context.Nurseries, "NurseryId", "Name");
            ViewData["ParentList2Id"] = new SelectList(_context.Gardens, "GardenId", "Name");
        }

        [BindProperty]
        public Plant Plant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Plants == null || Plant == null)
            {
                PopulateDropDowns();
                return Page();
            }

            _context.Plants.Add(Plant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
