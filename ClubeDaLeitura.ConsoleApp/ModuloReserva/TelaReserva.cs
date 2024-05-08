using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
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

        public RepositorioEmprestimo repositorioEmprestimo = null;

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
                    reserva.Id, reserva.Expirado ? "Sim" : "Não", reserva.DataReserva.ToShortDateString(),
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
            Revista revista = (Revista)repositorioRevista.SelecionarPorId(3);
            Reserva reserva = new Reserva(amigo, revista);
            repositorio.Cadastrar(reserva);

            Amigo amigo1 = (Amigo)repositorioAmigo.SelecionarPorId(3);
            Revista revista1 = (Revista)repositorioRevista.SelecionarPorId(1);
            Reserva reserva1 = new Reserva(amigo1, revista1);
            reserva1.DataLimite = DateTime.Parse("05/05/2024");
            repositorio.Cadastrar(reserva1);
        }

        public void ChecaValidadeReserva()
        {
            RepositorioReserva repositorioReserva = (RepositorioReserva)repositorio;
            repositorioReserva.ChecaValidacaoReservas();
        }

        public void RealizarEmprestimo()
        {
            ApresentarCabecalho();
            BuscarReservasEmAberto();

            Console.Write("Digite o ID da Reserva: ");
            int idReserva = int.Parse(Console.ReadLine());

            Reserva reserva = (Reserva)repositorio.SelecionarPorId(idReserva);

            Emprestimo emprestimo = new Emprestimo(reserva.Amigo, reserva.Revista);

            repositorioEmprestimo.Cadastrar(emprestimo);
            ExibirMensagem("Emprestimo realizado com sucesso", ConsoleColor.Green);
        }

        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"5 - Realizar empréstimo da {tipoEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }
        private void BuscarReservasEmAberto()
        {
            Console.WriteLine("Visualizando Reservas...");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20}",
                "Id", "Data da Reserva", "Data Limite", "Amigo", "Revista"
            );

            ArrayList reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                if (reserva == null)
                    continue;

                if (!reserva.Expirado)
                    Console.WriteLine(
                        "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20}",
                        reserva.Id, reserva.DataReserva.ToShortDateString(),
                        reserva.DataLimite.ToShortDateString(), reserva.Amigo.Nome, reserva.Revista.Titulo
                    );
            }

            Console.WriteLine();
        }
    }
}
