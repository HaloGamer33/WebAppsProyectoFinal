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
    public class IndexModel : PageModel
    {
        private readonly ProyectoFinal.Data.ProyectoFinalContext _context;

        public IndexModel(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            _context = context;
        }

        public IList<Dj> Dj { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Dj != null)
            {
                Dj = await _context.Dj.ToListAsync();
            }
        }
    }
}
