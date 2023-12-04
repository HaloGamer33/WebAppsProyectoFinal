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
    public class DetailsModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public DetailsModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

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
    }
}
