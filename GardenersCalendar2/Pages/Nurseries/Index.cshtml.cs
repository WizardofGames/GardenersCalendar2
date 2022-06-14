using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Identity;
using GardenersCalendar2.Data.GardenerUserNS;

namespace GardenersCalendar2.Pages.Nurseries
{
    public class IndexModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;
        public IndexModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Nursery> Nursery { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Nurseries != null)
            {
                string LoggedInUserId = _userManager.GetUserId(User);
                Nursery = await _context.Nurseries.Where(n => n.GardenerUserId == LoggedInUserId).ToListAsync();
            }
        }
    }
}
