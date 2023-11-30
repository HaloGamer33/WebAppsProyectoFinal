using System.ComponentModel.DataAnnotations;
namespace ProyectoFinal.Models;
public class Evento
{
    public int Id { get; set; }
    public string? Host { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
}
