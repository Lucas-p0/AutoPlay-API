using Autoglass.Autoplay.Dominio.Artistas.Entidades;
using Autoglass.Autoplay.Dominio.Artistas.Servicos.Comandos;

namespace Autoglass.Autoplay.Dominio.Artistas.Servicos.Interfaces
{
    public interface IArtistasServico
    {
        Artista Inserir(ArtistaComando comando);
        Artista Editar(ArtistaComando comando);
        Artista Instanciar(ArtistaComando comando);
        Artista Validar(int id);
    }
}