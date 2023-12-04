using System.ComponentModel.DataAnnotations;
namespace ProyectoFinal.Models;
public class Evento
{
    public int Id { get; set; }

    public Anfitrion? Anfitrion { get; set; }
    public int AnfitrionId { get; set; }

    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }

    public Dj? Dj { get; set; }
    public int DjId { get; set; }

    public InformacionPago? Pago { get; set; }
    public int PagoId { get; set; }

    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }
    public decimal Precio { get; set; }
    public int NoInvitados { get; set; }
}
