using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GardenersCalendar2.Pages.ToDos
{
    public class DeleteMultipleModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public DeleteMultipleModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDo> ToDo { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public List<int> CheckCompleted { get;set; }

        public async Task OnGetAsync()
        {
            ViewData["CheckedSelectList"] = new SelectList(CheckCompleted);
            if (_context.ToDos != null)
            {
                ToDo = await _context.ToDos
                .Include(t => t.Plant)
                .ThenInclude(p => p.Garden)
                .Include(t => t.Plant)
                .ThenInclude(p => p.Nursery)
                .Where(t => CheckCompleted.Contains(t.ToDoId))
                .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IQueryable<ToDo> CheckedToDos = _context.ToDos
                .Where(t => CheckCompleted.Contains(t.ToDoId));
                List<ToDo> toDos = CheckedToDos.ToList();
                _context.ToDos.RemoveRange(CheckedToDos);
                await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
