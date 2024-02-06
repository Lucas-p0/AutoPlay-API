using Autoglass.Autoplay.DataTransfer.Artistas.Request;
using Autoglass.Autoplay.DataTransfer.Artistas.Response;
using Autoglass.Autoplay.Dominio.Artistas.Entidades;
using Autoglass.Autoplay.Dominio.Artistas.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Artistas.Servicos.Comandos;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;

namespace Autoglass.Autoplay.Aplicacao.Artistas.Profiles
{
    public class ArtistasProfile : Profile
    {
        public ArtistasProfile()
        {
            CreateMap<ArtistaListarRequest, ArtistaListarFiltro>();
            CreateMap<ArtistaRequest, ArtistaComando>();
            CreateMap<Artista, ArtistaResponse>();
            CreateMap<PaginacaoConsulta<Artista>, PaginacaoConsulta<ArtistaResponse>>();
        }
    }
}