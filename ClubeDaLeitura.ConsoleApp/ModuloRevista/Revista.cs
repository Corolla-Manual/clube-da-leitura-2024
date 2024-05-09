using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista : EntidadeBase
    {
        public bool Emprestado { get; set; }
        public string Titulo { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public Caixa Caixa { get; set; }

        public Revista(string titulo, int edicao, int anoPublicacao, Caixa caixa)
        {
            Emprestado = false;
            Titulo = titulo;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            Caixa = caixa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"titulo\" é obrigatório");

            if (Edicao < 0)
                erros.Add("O campo \"edição\" é obrigatório");

            if (AnoPublicacao < 0)
                erros.Add("O campo \"ano de publicaão\" é obrigatório");

            if (Caixa == null)
                erros.Add("A caixa precisa ser informada");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Revista revista = (Revista)novoRegistro;

            this.Titulo = revista.Titulo;
            this.Emprestado = revista.Emprestado;
            this.Edicao = revista.Edicao;
            this.AnoPublicacao = revista.AnoPublicacao;
            this.Caixa = revista.Caixa;
        }
    }
}
