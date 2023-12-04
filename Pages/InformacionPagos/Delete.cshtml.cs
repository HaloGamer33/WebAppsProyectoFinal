using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Pages.InformacionPagos
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public DeleteModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public InformacionPago InformacionPago { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InformacionPago == null)
            {
                return NotFound();
            }

            var informacionpago = await _context.InformacionPago.FirstOrDefaultAsync(m => m.Id == id);

            if (informacionpago == null)
            {
                return NotFound();
            }
            else 
            {
                InformacionPago = informacionpago;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.InformacionPago == null)
            {
                return NotFound();
            }
            var informacionpago = await _context.InformacionPago.FindAsync(id);

            if (informacionpago != null)
            {
                InformacionPago = informacionpago;
                _context.InformacionPago.Remove(InformacionPago);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
