using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Autoplay.Dominio.Fornecedores.Entidades;
using Autoglass.Autoplay.Dominio.Fornecedores.Enumeradores;
using Autoglass.Autoplay.Dominio.Fornecedores.Repositorios;
using Autoglass.Autoplay.Dominio.Fornecedores.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using Autoglass.Autoplay.Infra.Utils.Repositorios;
using NHibernate;

namespace Autoglass.Autoplay.Infra.Fornecedores.Reposistorios
{
    public class FornecedoresRepositorio : RepositorioNHibernate<Fornecedor>, IFonecedoresRepositorio
    {
        public FornecedoresRepositorio(ISession session) : base(session)
        {
        }
        public IQueryable<Fornecedor> Filtrar(FornecedorListarFiltro filtro)
        {
            IQueryable<Fornecedor> query = Query().Where(x => x.Ativo == AtivoInativoEnum.Ativo);
            if (!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                query = query.Where(x => x.Nome.Contains(filtro.Nome));
                return query;
            }
            if (!string.IsNullOrWhiteSpace(filtro.Cnpj))
            {
                query = query.Where(x => x.Cnpj.Contains(filtro.Cnpj));
                return query;
            }
            query = filtro.TipoFornecedor switch
            {
                1 => query.Where(x => x.TipoFornecedor == TipoFornecedorEnum.PessoaFisica),
                2 => query.Where(x => x.TipoFornecedor == TipoFornecedorEnum.PessoaJuridica),
                _ => query,
            };
            return query;

        }



    }
}