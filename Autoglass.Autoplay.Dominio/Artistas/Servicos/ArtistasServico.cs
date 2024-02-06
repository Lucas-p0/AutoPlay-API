using Autoglass.Autoplay.Dominio.Artistas.Entidades;
using Autoglass.Autoplay.Dominio.Artistas.Enumeradores;
using Autoglass.Autoplay.Dominio.Artistas.Repositorios;
using Autoglass.Autoplay.Dominio.Artistas.Servicos.Comandos;
using Autoglass.Autoplay.Dominio.Artistas.Servicos.Interfaces;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;

namespace Autoglass.Autoplay.Dominio.Artistas.Servicos
{
    public class ArtistasServico : IArtistasServico
    {
        private readonly IArtistasRepositorio artistasRepositorio;
        public ArtistasServico(IArtistasRepositorio artistasRepositorio)
        {
            this.artistasRepositorio = artistasRepositorio;
        }

        public Artista Editar(ArtistaComando comando)
        {
            Artista artista = Validar(comando.Id);
            artista.SetNome(comando.Nome);
            artista.SetTipoGeneroMusical(comando.TipoGeneroMusical);
            artistasRepositorio.Editar(artista);
            return artista;
        }

        public Artista Inserir(ArtistaComando comando)
        {
            Artista artista = Instanciar(comando);
            artistasRepositorio.Inserir(artista);
            return artista;
        }

        public Artista Instanciar(ArtistaComando comando)
        {
            return new(comando.Nome, comando.TipoGeneroMusical);
        }

        public Artista Validar(int id)
        {
           Artista artista = artistasRepositorio.Recuperar(id);

           if(artista is null)
            throw new RegraDeNegocioExcecao("Artista não encontrado");

            return artista;
        }

        private static TipoGeneroMusicalEnum ValidarTipoGeneroMusical(int tipoGeneroMusical)
        {
            TipoGeneroMusicalEnum tipoGeneroMusicalEnum = tipoGeneroMusical switch
            {
                1 => TipoGeneroMusicalEnum.Rock,
                2 => TipoGeneroMusicalEnum.Pop,
                3 => TipoGeneroMusicalEnum.Folk,
                4 => TipoGeneroMusicalEnum.Samba,
                _ => throw new RegraDeNegocioExcecao("Tipo de genero musical inválido"),
            };

            return tipoGeneroMusicalEnum;            
        }
    }
}