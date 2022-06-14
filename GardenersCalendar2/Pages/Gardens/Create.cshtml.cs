using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Identity;
using GardenersCalendar2.Data.GardenerUserNS;

namespace GardenersCalendar2.Pages.Gardens
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<GardenerUserClass> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            string LoggedInGardenerId = _userManager.GetUserId(User);
            Garden = new Garden();
            Garden.GardenerUserId = LoggedInGardenerId;
            return Page();
        }

        [BindProperty]
        public Garden Garden { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Gardens == null || Garden == null)
            {
                return Page();
            }

            Garden.GardenerUserId = _userManager.GetUserId(User);
            _context.Gardens.Add(Garden);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
