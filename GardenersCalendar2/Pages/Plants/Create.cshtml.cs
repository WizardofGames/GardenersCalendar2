using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Identity;
using GardenersCalendar2.Data.GardenerUserNS;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace GardenersCalendar2.Pages.Plants
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;
        public enum ParentIdType
        {
            None, Nursery, Garden
        }
        public CreateModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            string LoggedInUserId = _userManager.GetUserId(User);
            //Garden = await _context.Gardens.Where(g => g.GardenerUserId == LoggedInUserId).ToListAsync();
            ViewData["NurseryId"] = new SelectList(_context.Nurseries.Where(n => n.GardenerUserId == LoggedInUserId), "NurseryId", "Name");
            ViewData["GardenId"] = new SelectList(_context.Gardens.Where(g => g.GardenerUserId == LoggedInUserId), "GardenId", "Name");
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
