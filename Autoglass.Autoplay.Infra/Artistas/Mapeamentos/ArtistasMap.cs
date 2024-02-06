using Autoglass.Autoplay.Dominio.Artistas.Entidades;
using Autoglass.Autoplay.Dominio.Artistas.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using FluentNHibernate.Mapping;

namespace Autoglass.Autoplay.Infra.Artistas.Mapeamentos
{
    public class ArtistasMap : ClassMap<Artista>
    {
       public ArtistasMap()
       {
            Schema("autoplay");
            Table("artista");
            Id(x => x.Id, "id");
            Map(x => x.Nome, "nome");
            Map(x => x.TipoGeneroMusical, "tipogeneromusical").CustomType<TipoGeneroMusicalEnum>();
            Map(x => x.Ativo, "ativo").CustomType<AtivoInativoEnum>();
       } 
    }
}