namespace Autoglass.Autoplay.DataTransfer.Artistas.Response
{
    public record ArtistaResponse
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public int TipoGeneroMusical { get; init; }
        public ArtistaResponse(){}
    }
}