using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.Nurseries
{
    public class DetailsModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;
        public List<ToDo> ToDoList { get; set; }

        public DetailsModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Nursery Nursery { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nurseries == null)
            {
                return NotFound();
            }

            var nursery = await _context.Nurseries.Include(n => n.Plants).ThenInclude(p => p.ToDo).FirstOrDefaultAsync(m => m.NurseryId == id);
            if (nursery == null)
            {
                return NotFound();
            }
            else 
            {
                Nursery = nursery;
            }
            ToDoList = Nursery.Plants.SelectMany(p => p.ToDo).ToList();
            return Page();
        }
    }
}
