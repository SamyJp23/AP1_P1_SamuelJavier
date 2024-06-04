using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AP1_P1_SamuelJavier.Models;

public class Articulos
    
{

    [Key]
    [Range(1, int.MaxValue,ErrorMessage = "El id debe ser mayor que 0")]
      public int IdArticulo { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
      public string? Descripcion { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "El  Costo ser mayor que 0")]
    public decimal Costo { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "La Ganancia debe ser mayor que 0")]
    public decimal Ganancia { get; set; }
     [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
    public decimal Precio { get; set; }

       
        
}
