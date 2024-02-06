using Autoglass.Autoplay.Dominio.Artistas.Entidades;
using Autoglass.Autoplay.Dominio.Artistas.Enumeradores;
using Autoglass.Autoplay.Dominio.Artistas.Repositorios;
using Autoglass.Autoplay.Dominio.Artistas.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Infra.Utils.Repositorios;
using NHibernate;

namespace Autoglass.Autoplay.Infra.Artistas.Repositorios
{
    public class ArtistasRepositorio : RepositorioNHibernate<Artista>, IArtistasRepositorio
    {
        public ArtistasRepositorio(ISession session) : base(session){}

        public IQueryable<Artista> Filtrar(ArtistaListarFiltro filtro)
        {
            IQueryable<Artista> query = Query().Where(x => x.Ativo == AtivoInativoEnum.Ativo);

            if(!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                query = query.Where(x => x.Nome.ToUpper().Trim() == filtro.Nome.ToUpper().Trim());
            }

            query = filtro.TipoGeneroMusical switch
            {
                1 => query.Where(x => x.TipoGeneroMusical == TipoGeneroMusicalEnum.Rock),
                2 => query.Where(x => x.TipoGeneroMusical == TipoGeneroMusicalEnum.Pop),
                3 => query.Where(x => x.TipoGeneroMusical == TipoGeneroMusicalEnum.Folk),
                4 => query.Where(x => x.TipoGeneroMusical == TipoGeneroMusicalEnum.Samba),
                _ => query,
            };

            return query;            
        }

        public void Inativar(Artista artista)
        {
            artista.SetAtivo(AtivoInativoEnum.Inativo);
            Editar(artista);
        }
    }
}