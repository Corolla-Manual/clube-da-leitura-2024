using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class Amigo : EntidadeBase
    {
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public Multa Multa { get; set; }

        public Amigo(string nome, string nomeresponsavel, string telefone, string endereco)
        {
            Nome = nome;
            NomeResponsavel = nomeresponsavel;
            Telefone = telefone;
            Endereco = endereco;
            Multa = new Multa();
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(NomeResponsavel.Trim()))
                erros.Add("O campo \"nome do responsável\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"Telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Endereco.Trim()))
                erros.Add("O campo \"Endereço\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Amigo novasInformacoes = (Amigo)novoRegistro;

            this.Nome = novasInformacoes.Nome;
            this.NomeResponsavel = novasInformacoes.NomeResponsavel;
            this.Telefone = novasInformacoes.Telefone;
            this.Endereco = novasInformacoes.Endereco;
        }
    }
}
