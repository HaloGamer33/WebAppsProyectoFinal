using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Pages.Djs
{
    public class EditModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public EditModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dj Dj { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dj == null)
            {
                return NotFound();
            }

            var dj =  await _context.Dj.FirstOrDefaultAsync(m => m.Id == id);
            if (dj == null)
            {
                return NotFound();
            }
            Dj = dj;
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

            _context.Attach(Dj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DjExists(Dj.Id))
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

        private bool DjExists(int id)
        {
          return (_context.Dj?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
