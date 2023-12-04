using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Pages.Djs
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public DeleteModel(ProyectoFinal.Data.ProyectoFinalContext context)
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

            var dj = await _context.Dj.FirstOrDefaultAsync(m => m.Id == id);

            if (dj == null)
            {
                return NotFound();
            }
            else 
            {
                Dj = dj;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dj == null)
            {
                return NotFound();
            }
            var dj = await _context.Dj.FindAsync(id);

            if (dj != null)
            {
                Dj = dj;
                _context.Dj.Remove(Dj);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
