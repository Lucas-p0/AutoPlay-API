using System;
using System.Collections.Generic;
using Autoglass.Autoplay.Dominio.Utils.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Filtros.Enumeradores;

namespace Autoglass.Autoplay.DataTransfer.Artistas.Request
{
    public class ArtistaListarRequest : PaginacaoFiltro
    {
        public string Nome { get; set; }
        public int TipoGeneroMusical { get; set; }
        public ArtistaListarRequest() : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc){}
    }
}