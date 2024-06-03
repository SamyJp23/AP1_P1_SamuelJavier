using Microsoft.EntityFrameworkCore;
using AP1_P1_SamuelJavier.Models;
namespace AP1_P1_SamuelJavier.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) 
        : base(options) { }

    DbSet<Articulos> Articulos { get; set; }
}
