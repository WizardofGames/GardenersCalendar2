using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Identity;
using GardenersCalendar2.Data.GardenerUserNS;

namespace GardenersCalendar2.Pages.Nurseries
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly UserManager<GardenerUserClass> _userManager;
        public CreateModel(GardenersCalendar2.Data.ApplicationDbContext context, UserManager<GardenerUserClass> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            string LoggedInGardenerId = _userManager.GetUserId(User);
            Nursery = new Nursery();
            Nursery.GardenerUserId = LoggedInGardenerId;
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

            Nursery.GardenerUserId = _userManager.GetUserId(User);
            _context.Nurseries.Add(Nursery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
