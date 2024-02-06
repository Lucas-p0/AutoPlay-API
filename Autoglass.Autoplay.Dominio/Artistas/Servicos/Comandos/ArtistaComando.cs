using Autoglass.Autoplay.Dominio.Artistas.Enumeradores;

namespace Autoglass.Autoplay.Dominio.Artistas.Servicos.Comandos
{
    public class ArtistaComando
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoGeneroMusicalEnum TipoGeneroMusical { get; set; }
    }
}