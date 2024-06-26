﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class TelaReserva : TelaBase<Reserva>, ITelaCadastravel
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
                "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20} | {5, -20} | {6,-10}",
                "Id", "Expirado", "Data da Reserva", "Data Limite", "Amigo", "Revista", "Concluído"
            );

            List<Reserva> reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                if (reserva == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -16} | {3,-15} | {4, -20} | {5, -20} | {6,-10}",
                    reserva.Id, reserva.Expirado ? "Sim" : "Não", reserva.DataReserva.ToShortDateString(),
                    reserva.DataLimite.ToShortDateString(), reserva.Amigo.Nome, reserva.Revista.Titulo,
                    reserva.Concluido ? "Sim" : "Não"
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        protected override Reserva ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);
            Console.Write("Informe o ID do amigo que vai fazer o emprestimo: ");
            int idAmigo = int.Parse(Console.ReadLine());
            Amigo amigo = repositorioAmigo.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);
            Console.Write("Informe o ID da revista que vai ser emprestada: ");
            int idRevista = int.Parse(Console.ReadLine());
            Revista revista = repositorioRevista.SelecionarPorId(idRevista);

            Reserva reserva = new Reserva(amigo, revista);

            return reserva;
        }

        public void CadastrarEntidadeTeste()
        {
            Amigo amigo = repositorioAmigo.SelecionarPorId(1);
            Revista revista = repositorioRevista.SelecionarPorId(3);
            Reserva reserva = new Reserva(amigo, revista);
            repositorio.Cadastrar(reserva);

            Amigo amigo1 = repositorioAmigo.SelecionarPorId(3);
            Revista revista1 = repositorioRevista.SelecionarPorId(1);
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

            Reserva reserva = repositorio.SelecionarPorId(idReserva);

            if (reserva.Amigo.Multa.MultaAberta)
            {
                ExibirMensagem($"O amigo {reserva.Amigo.Nome} possui uma multa em aberto!", ConsoleColor.Red);
                return;
            }

            if (reserva.Expirado)
            {
                ExibirMensagem($"Impossível realizar empréstimo, a reserva esta expirada!", ConsoleColor.Red);
                return;
            }

            if (reserva.Concluido)
            {
                ExibirMensagem($"A reserva já foi emprestada!", ConsoleColor.Red);
                return;
            }
            reserva.Concluido = true;
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
            Console.WriteLine($"2 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"3 - Realizar empréstimo da {tipoEntidade}s");

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

            List<Reserva> reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                if (reserva == null)
                    continue;

                if (!reserva.Expirado && !reserva.Concluido)
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
