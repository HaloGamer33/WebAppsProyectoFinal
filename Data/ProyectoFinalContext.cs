using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class ProyectoFinalContext : DbContext
    {
        public ProyectoFinalContext (DbContextOptions<ProyectoFinalContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoFinal.Models.Evento> Evento { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.Anfitrion> Anfitrion { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.Categoria> Categoria { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.Dj> Dj { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.InformacionPago> InformacionPago { get; set; } = default!;
    }
}
