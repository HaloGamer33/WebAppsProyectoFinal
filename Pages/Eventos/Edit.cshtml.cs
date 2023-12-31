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

namespace ProyectoFinal.Pages.Eventos
{
    public class EditModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public EditModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Evento == null)
            {
                return NotFound();
            }

            var evento =  await _context.Evento.FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            Evento = evento;
           ViewData["AnfitrionId"] = new SelectList(_context.Set<Anfitrion>(), "Id", "Id");
           ViewData["CategoriaId"] = new SelectList(_context.Set<Categoria>(), "Id", "Id");
           ViewData["DjId"] = new SelectList(_context.Set<Dj>(), "Id", "Id");
           ViewData["PagoId"] = new SelectList(_context.Set<InformacionPago>(), "Id", "Id");
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

            _context.Attach(Evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(Evento.Id))
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

        private bool EventoExists(int id)
        {
          return (_context.Evento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
