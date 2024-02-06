using System.Text.RegularExpressions;
using Autoglass.Autoplay.Dominio.Fornecedores.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;

namespace Autoglass.Autoplay.Dominio.Fornecedores.Entidades;

public class Fornecedor
{
    public virtual int ID { get; protected set; }
    public virtual string Nome { get; protected set; }
    public virtual string Cnpj { get; protected set; }
    public virtual TipoFornecedorEnum TipoFornecedor { get; protected set; }

    public virtual AtivoInativoEnum Ativo { get; protected set; }
    public Fornecedor(string nome, string cnpj, TipoFornecedorEnum tipoFornecedor)
    {
        SetNome(nome);
        SetCnpj(cnpj);
        SetTipoFornecedor(tipoFornecedor);
        SetAtivo(AtivoInativoEnum.Ativo);
    }

    public virtual void SetAtivo(AtivoInativoEnum ativo)
    {
        Ativo = ativo;
    }


    public virtual void SetTipoFornecedor(TipoFornecedorEnum tipoFornecedor)
    {
        TipoFornecedor = tipoFornecedor;
    }


    public virtual void SetCnpj(string cnpj)
    {
        const string NOME_ATRIBUTO = "Cnpj";
        const int TAMANHO_ATRIBUTO = 14;

        if (string.IsNullOrWhiteSpace(cnpj))
        {
            throw new AtributoObrigatorioExcecao(NOME_ATRIBUTO);
        }

        if (cnpj.Length > TAMANHO_ATRIBUTO)
        {
            throw new TamanhoDeAtributoInvalidoExcecao(NOME_ATRIBUTO, 0, TAMANHO_ATRIBUTO);
        }

        if (!Regex.IsMatch(cnpj, "\\d{14}"))
        {
            throw new AtributoObrigatorioExcecao(NOME_ATRIBUTO);
        }
        Cnpj = cnpj;
    }


    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new AtributoObrigatorioExcecao("Nome");
        }
        Nome = nome;
    }


    protected Fornecedor() { }

}
