using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : RepositorioBase
    {
        public void ValidaDataLimiteEmprestimo()
        {
            foreach (Emprestimo emprestimo in registros)
            {
                if (DateTime.Now > emprestimo.DataDevolucao)
                {
                    emprestimo.Amigo.Multa.MultaAberta = true;
                }
            }
        }
        public void ChecaValidacaoStatus()
        {
            foreach (Emprestimo emprestimo in registros)
            {
                if ()
                {
                    emprestimo.Concluido = true;
                }
            }
        }

    }
}
