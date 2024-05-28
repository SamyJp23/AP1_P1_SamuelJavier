using Microsoft.EntityFrameworkCore;
namespace AP1_P1_SamuelJavier.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) 
        : base(options) { }
}
