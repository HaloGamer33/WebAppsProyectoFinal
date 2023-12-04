using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Pages.Anfitriones
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
            return Page();
        }

        [BindProperty]
        public Anfitrion Anfitrion { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Anfitrion == null || Anfitrion == null)
            {
                return Page();
            }

            _context.Anfitrion.Add(Anfitrion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
