using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Pages.Eventos
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public CreateModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnfitrionId"] = new SelectList(_context.Set<Anfitrion>(), "Id", "Id");
        ViewData["CategoriaId"] = new SelectList(_context.Set<Categoria>(), "Id", "Id");
        ViewData["DjId"] = new SelectList(_context.Set<Dj>(), "Id", "Id");
        ViewData["PagoId"] = new SelectList(_context.Set<InformacionPago>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Evento Evento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Evento == null || Evento == null)
            {
                return Page();
            }

            _context.Evento.Add(Evento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
