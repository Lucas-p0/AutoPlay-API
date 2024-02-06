using Autoglass.Autoplay.Dominio.Fornecedores.Entidades;
using Autoglass.Autoplay.Dominio.Fornecedores.Repositorios.Filtros;
using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;

namespace Autoglass.Autoplay.Dominio.Fornecedores.Repositorios;

public interface IFonecedoresRepositorio : IRepositorioNHibernate<Fornecedor>
{
    IQueryable<Fornecedor> Filtrar(FornecedorListarFiltro filtro);

}
