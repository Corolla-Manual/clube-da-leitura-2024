using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class TelaReserva : TelaBase
    {
        public TelaAmigo telaAmigo = null;
        public RepositorioAmigo repositorioAmigo = null;

        public TelaRevista telaRevista = null;
        public RepositorioRevista repositorioRevista = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Reservas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20} | {5, -20}",
                "Id", "Expirado", "Data da Reserva", "Data Limite", "Amigo", "Revista"
            );

            ArrayList reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                if (reserva == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20} | {5, -20}",
                    reserva.Id, reserva.Expirado, reserva.DataReserva.ToShortDateString(),
                    reserva.DataLimite.ToShortDateString(), reserva.Amigo.Nome, reserva.Revista.Titulo
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);
            Console.Write("Informe o ID do amigo que vai fazer o emprestimo: ");
            int idAmigo = int.Parse(Console.ReadLine());
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);
            Console.Write("Informe o ID da revista que vai ser emprestada: ");
            int idRevista = int.Parse(Console.ReadLine());
            Revista revista = (Revista)repositorio.SelecionarPorId(idRevista);

            Reserva reserva = new Reserva(amigo, revista);

            return reserva;
        }

        public void CadastrarEntidadeTeste()
        {
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPorId(1);
            Revista revista = (Revista)repositorioRevista.SelecionarPorId(1);
            Reserva reserva = new Reserva(amigo, revista);
            repositorio.Cadastrar(reserva);
        }
    }
}
