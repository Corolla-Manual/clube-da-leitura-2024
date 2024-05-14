using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : RepositorioBase<Emprestimo>
    {
        public void ValidaDataLimiteEmprestimo()
        {
            foreach (Emprestimo emprestimo in registros)
            {
                if (emprestimo.Amigo.Multa.Pago)
                {
                    emprestimo.Concluido = true;
                    emprestimo.Amigo.Multa.Pago = false;
                }

                if (DateTime.Now > emprestimo.DataDevolucao && !emprestimo.Concluido)
                {
                    emprestimo.Amigo.Multa.MultaAberta = true;
                }
            }
        }
    }
}
