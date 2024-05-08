﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Incialização Amigo
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.tipoEntidade = "Amigo";
            telaAmigo.repositorio = repositorioAmigo;
            telaAmigo.CadastrarEntidadeTeste();

            //Inicialização Caixa
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;
            telaCaixa.CadastrarEntidadeTeste();

            //Inicialização Revista
            RepositorioRevista repositorioRevista = new RepositorioRevista();

            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorio = repositorioRevista;
            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.CadastrarEntidadeTeste();

            //Inicialização Reserva
            RepositorioReserva repositorioReserva = new RepositorioReserva();

            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.telaRevista = telaRevista;
            telaReserva.telaAmigo = telaAmigo;
            telaReserva.repositorio = repositorioReserva;
            telaReserva.repositorioRevista = repositorioRevista;
            telaReserva.repositorioAmigo = repositorioAmigo;
            telaReserva.CadastrarEntidadeTeste();

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaAmigo;
                if (opcaoPrincipalEscolhida == '2')
                    tela = telaCaixa;
                if (opcaoPrincipalEscolhida == '3')
                    tela = telaRevista;
                if (opcaoPrincipalEscolhida == '4')
                    tela = telaReserva;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
            }
            Console.ReadLine();
        }
    }
}

