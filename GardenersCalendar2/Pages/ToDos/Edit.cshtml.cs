﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Pages.ToDos
{
    public class EditModel : PageModel
    {
        private readonly GardenersCalendar2.Data.ApplicationDbContext _context;

        public EditModel(GardenersCalendar2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDo ToDo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var todo =  await _context.ToDos.FirstOrDefaultAsync(m => m.ToDoId == id);
            if (todo == null)
            {
                return NotFound();
            }
            ToDo = todo;
           ViewData["ParentListId"] = new SelectList(_context.Plants, "PlantId", "PlantId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(ToDo.ToDoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoExists(int id)
        {
          return (_context.ToDos?.Any(e => e.ToDoId == id)).GetValueOrDefault();
        }
    }
}
