using Autoglass.Autoplay.Aplicacao.Artistas.Servicos.Interfaces;
using Autoglass.Autoplay.DataTransfer.Artistas.Request;
using Autoglass.Autoplay.DataTransfer.Artistas.Response;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using Microsoft.AspNetCore.Mvc;

namespace Autoglass.Autoplay.API.Controllers.Artistas
{
    [ApiController]
    [Route("api/artistas")]
    public class ArtistasController : ControllerBase
    {
        private readonly IArtistasAppServico artistasAppServico;

        public ArtistasController(IArtistasAppServico artistasAppServico)
        {
            this.artistasAppServico = artistasAppServico;
        }

         /// <summary>
        /// Recupera um artista por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ArtistaResponse> Recuperar(int id)
        {
            var response = artistasAppServico.Recuperar(id);
            return Ok(response);
        }
        
        /// <summary>
        /// Listar artistas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PaginacaoConsulta<ArtistaResponse>> Listar([FromQuery] ArtistaListarRequest request)
        {
            var response = artistasAppServico.Listar(request);
            return Ok(response);
        }

        /// <summary>
        /// Editar um artista por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Editar(int id, [FromBody] ArtistaRequest request)
        {
            artistasAppServico.Editar(id, request);
            return Ok();
        }

        /// <summary>
        /// Excluir um artista por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult ExcluirAsync(int id)
        {
            artistasAppServico.Excluir(id);
            return Ok();
        }

        ///<summary>
        /// Criar artista.
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public ActionResult<ArtistaResponse> Inserir([FromBody] ArtistaRequest request)
        {
            var response = artistasAppServico.Inserir(request);
            return Ok(response);
        } 
    }
}