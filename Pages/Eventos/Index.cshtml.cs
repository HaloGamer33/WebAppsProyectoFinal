using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Pages.Eventos
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public IndexModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

        public IList<Evento> Evento { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Evento != null)
            {
                Evento = await _context.Evento
                .Include(e => e.Anfitrion)
                .Include(e => e.Categoria)
                .Include(e => e.Dj)
                .Include(e => e.Pago).ToListAsync();
            }
        }
    }
}
