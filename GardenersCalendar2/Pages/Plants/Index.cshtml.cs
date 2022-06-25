using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using GardenersCalendar2.Data.GardenerUserNS;
using Microsoft.AspNetCore.Identity;

namespace GardenersCalendar2.Pages.Plants
{
    public class IndexModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;

        public IndexModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass>? userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Plant> Plant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Plants != null)
            {
                Plant = await _context.Plants
                .Include(p => p.Nursery)
                .Include(p => p.Garden)
                .Where(t => t.GardenerUserId == _userManager.GetUserId(User))
                .ToListAsync();
            }
        }
    }
}
