using Autoglass.Autoplay.DataTransfer.Artistas.Request;
using Autoglass.Autoplay.DataTransfer.Artistas.Response;
using Autoglass.Autoplay.Dominio.Utils.Consultas;

namespace Autoglass.Autoplay.Aplicacao.Artistas.Servicos.Interfaces
{
    public interface IArtistasAppServico
    {
        PaginacaoConsulta<ArtistaResponse> Listar(ArtistaListarRequest request);
        ArtistaResponse Inserir(ArtistaRequest request);
        ArtistaResponse Editar(int id, ArtistaRequest request);
        void Excluir(int id);
        ArtistaResponse Recuperar(int id);
    }
}