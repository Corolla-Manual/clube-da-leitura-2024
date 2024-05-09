using ClubeDaLeitura.ConsoleApp.Compartilhado;

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
    }
}
