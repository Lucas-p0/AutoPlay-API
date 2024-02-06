using System.ComponentModel;

namespace Autoglass.Autoplay.Dominio.Fornecedores.Enumeradores;

public enum TipoFornecedorEnum
{
    [Description("Pessoa Fisica")]
    PessoaFisica = 1,
    [Description("Pessoa Juridica")]
    PessoaJuridica = 2,
}
