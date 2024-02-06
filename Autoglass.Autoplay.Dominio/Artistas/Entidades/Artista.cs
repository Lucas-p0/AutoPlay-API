using Autoglass.Autoplay.Dominio.Artistas.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Enumeradores;
using Autoglass.Autoplay.Dominio.Utils.Excecoes;

namespace Autoglass.Autoplay.Dominio.Artistas.Entidades
{
    public class Artista
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual TipoGeneroMusicalEnum TipoGeneroMusical { get; protected set; }
        public virtual AtivoInativoEnum Ativo { get; protected set; }
        public Artista(string nome, TipoGeneroMusicalEnum tipoGeneroMusical)
        {
            SetNome(nome);
            SetTipoGeneroMusical(tipoGeneroMusical);
            SetAtivo(AtivoInativoEnum.Ativo);
        }

        protected Artista(){}

        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new AtributoObrigatorioExcecao("Nome");

            Nome = nome;
        }

        public virtual void SetTipoGeneroMusical(TipoGeneroMusicalEnum tipoGeneroMusicalEnum)
        {
            TipoGeneroMusical = tipoGeneroMusicalEnum;
        }

        public virtual void SetAtivo(AtivoInativoEnum ativo)
        {
            Ativo = ativo;
        }
    }
}