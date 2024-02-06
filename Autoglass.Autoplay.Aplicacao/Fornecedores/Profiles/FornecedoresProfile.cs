using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.DataTransfer.Artistas.Request;
using Autoglass.Autoplay.DataTransfer.Fornecedores.Request;
using Autoglass.Autoplay.DataTransfer.Fornecedores.Request.Response;
using Autoglass.Autoplay.Dominio.Fornecedores.Entidades;
using Autoglass.Autoplay.Dominio.Fornecedores.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Fornecedores.Servicos.Comandos;
using Autoglass.Autoplay.Dominio.Utils.Consultas;
using AutoMapper;

namespace Autoglass.Autoplay.Aplicacao.Fornecedores.Profiles
{
    public class FornecedoresProfile : Profile
    {
        public FornecedoresProfile()
        {
            CreateMap<FornecedorInseriRequest, FornecedorInserirComando>();
            CreateMap<ArtistaListarRequest, FornecedorListarFiltro>();
            CreateMap<Fornecedor, FornecedorResponse>();
            //CreateMap<PaginacaoConsulta<Fornecedor>, PaginacaoConsulta<FornecedorResponse>();



        }
    }
}