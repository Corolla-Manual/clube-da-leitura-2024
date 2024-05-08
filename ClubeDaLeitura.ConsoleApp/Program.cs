using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
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

            //Inicialização Empréstimo
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Empréstimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;
            telaEmprestimo.telaRevista = telaRevista;
            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.CadastrarEntidadeTeste();

            //Inicialização Reserva
            RepositorioReserva repositorioReserva = new RepositorioReserva();

            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.telaRevista = telaRevista;
            telaReserva.telaAmigo = telaAmigo;
            telaReserva.repositorio = repositorioReserva;
            telaReserva.repositorioRevista = repositorioRevista;
            telaReserva.repositorioAmigo = repositorioAmigo;
            telaReserva.repositorioEmprestimo = repositorioEmprestimo;
            telaReserva.CadastrarEntidadeTeste();

            while (true)
            {
                telaEmprestimo.ChecaValidadeMultas();
                telaReserva.ChecaValidadeReserva();

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
                if (opcaoPrincipalEscolhida == '5')
                    tela = telaEmprestimo;



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

                else if (operacaoEscolhida == '5' && opcaoPrincipalEscolhida == '4')
                    telaReserva.RealizarEmprestimo();

                else if (operacaoEscolhida == '5' && opcaoPrincipalEscolhida == '1')
                    telaAmigo.VisualizarRegistrosComMultas(true);

                else if (operacaoEscolhida == '6' && opcaoPrincipalEscolhida == '1')
                    telaAmigo.QuitarMulta();
            }
            Console.ReadLine();
        }
    }
}

