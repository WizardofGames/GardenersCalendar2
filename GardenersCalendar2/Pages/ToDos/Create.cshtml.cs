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
using GardenersCalendar2.Services;
using Microsoft.EntityFrameworkCore;

namespace GardenersCalendar2.Pages.ToDos
{
    public partial class CreateModel : PageModel
    {

        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;
        private readonly ToDoService _toDoService;

        public CreateModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager, ToDoService toDoService)
        {
            _context = context;
            _userManager = userManager;
            _toDoService = toDoService;
        }

        public IActionResult OnGet()
        {
            ToDoVm.StartDate = DateTime.Today;
            ToDoVm.EndDate = DateTime.Today;
            IQueryable<Plant> plantsForLoggedInUser = _context.Plants
                        .Include(p => p.Garden)
                        .Include(p => p.Nursery)
                        .Where(t => t.GardenerUserId == _userManager.GetUserId(User));

            ViewData["ParentListId"] = new SelectList(plantsForLoggedInUser, "PlantId", "DropdownDescription");
            return Page();
        }

        [BindProperty(SupportsGet = true)]
                public ToDoViewModel ToDoVm { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            string userId = _userManager.GetUserId(User);
            _toDoService.GeneratesRecurringToDosFromUserInput(userId, ToDoVm);

            return RedirectToPage("./Index");
        }
    }
}
