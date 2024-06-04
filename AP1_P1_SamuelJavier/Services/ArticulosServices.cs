using AP1_P1_SamuelJavier.DAL;
using AP1_P1_SamuelJavier.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
namespace AP1_P1_SamuelJavier.Services;

public class ArticulosServices
{
    private readonly Contexto _contexto;

    public ArticulosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Articulos
            .AnyAsync(a => a.IdArticulo == id);

    }

    public async Task<bool> Insertar(Articulos articulo)
    {
        _contexto.Articulos.Add(articulo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Modificar(Articulos articulo)
    {
        _contexto.Add(articulo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminar(int id)
    {
        var articulo = await _contexto.Articulos
             .Where(a => a.IdArticulo == id)
             .ExecuteDeleteAsync();
        return articulo > 0;
    }

        public async Task<bool> Guardar(Articulos articulo)
        {
         if(await ExisteDescripcion(articulo.Descripcion, articulo.IdArticulo))
        {
            return false;
        }
         if(! await Existe(articulo.IdArticulo))
            {
            return await Insertar(articulo);
        }
        else
        {
            return await Modificar(articulo);
        }
        }

    public async Task<bool> ExisteDescripcion(string descripcion,int? id = null)
    {
        if (id.HasValue)
        {
            return await _contexto.Articulos.AnyAsync(a => a.Descripcion == descripcion && a.IdArticulo != id);
        }
        else
        {
            return await _contexto.Articulos.AnyAsync(a => a.Descripcion == descripcion);
        }

    }

    public async Task<Articulos?> Buscar(int id)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdArticulo == id);
    }
    public List<Articulos> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        return _contexto.Articulos
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}

