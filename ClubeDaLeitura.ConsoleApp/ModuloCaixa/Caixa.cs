using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }
        public ArrayList Revista { get; set; }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new();

            if (string.IsNullOrEmpty(Etiqueta.Trim()))
                erros.Add("O campo \"etiqueta\" é obrigatório");

            if (string.IsNullOrEmpty(Cor.Trim()))
                erros.Add("O campo \"cor\" é obrigatório");

            if (DiasEmprestimo < 1)
                erros.Add("O campo \"dias de emprestimo\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Caixa caixa = (Caixa)novoRegistro;

            this.Etiqueta = caixa.Etiqueta;
            this.Cor = caixa.Cor;
            this.DiasEmprestimo = caixa.DiasEmprestimo;
            this.Revista = caixa.Revista;
        }
    }
}
