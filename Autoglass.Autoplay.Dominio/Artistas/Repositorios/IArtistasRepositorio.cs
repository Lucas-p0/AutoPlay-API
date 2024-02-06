using Autoglass.Autoplay.Dominio.Artistas.Entidades;
using Autoglass.Autoplay.Dominio.Artistas.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;

namespace Autoglass.Autoplay.Dominio.Artistas.Repositorios
{
    public interface IArtistasRepositorio : IRepositorioNHibernate<Artista>
    {
        IQueryable<Artista> Filtrar(ArtistaListarFiltro filtro);
        void Inativar(Artista artista);
    }
}