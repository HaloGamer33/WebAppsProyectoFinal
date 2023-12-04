using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Pages.Anfitriones
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public DetailsModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

      public Anfitrion Anfitrion { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Anfitrion == null)
            {
                return NotFound();
            }

            var anfitrion = await _context.Anfitrion.FirstOrDefaultAsync(m => m.Id == id);
            if (anfitrion == null)
            {
                return NotFound();
            }
            else 
            {
                Anfitrion = anfitrion;
            }
            return Page();
        }
    }
}
