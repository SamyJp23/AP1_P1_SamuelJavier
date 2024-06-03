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

    [Required(ErrorMessage = "El campo es obligatorio")]  
    public decimal Costo { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal Ganancia { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal Precio { get; set; }

       
        
}
