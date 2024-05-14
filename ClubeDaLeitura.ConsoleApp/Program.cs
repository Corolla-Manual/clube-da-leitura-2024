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
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            TelaReserva telaReservas = new TelaReserva();
            TelaEmprestimo telaEmprestimos = new TelaEmprestimo();

            while (true)
            {
                telaEmprestimos.ChecaValidadeMultas();
                telaReservas.ChecaValidadeReserva();

                ITelaCadastravel tela = telaPrincipal.ApresentarMenuPrincipal();

                if (tela == null)
                    break;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (tela is TelaEmprestimo telaEmprestimo)               
                    GerenciarEmprestimos(operacaoEscolhida, telaEmprestimo);
                
                else if (tela is TelaReserva telaReserva)               
                    GerenciarReservas(operacaoEscolhida, telaReserva);                

                if (operacaoEscolhida == 'S')
                        continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2' && (opcaoPrincipalEscolhida == '4' || opcaoPrincipalEscolhida == '5'))
                    tela.VisualizarRegistros(true);

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3' && opcaoPrincipalEscolhida == '4')
                    telaReserva.RealizarEmprestimo();

                else if (operacaoEscolhida == '3' && opcaoPrincipalEscolhida == '5')
                    telaEmprestimo.VisualizarRegistrosDoDia(true);

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4' && opcaoPrincipalEscolhida == '5')
                    telaEmprestimo.VisualizarRegistrosDoMes(true);

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);

                else if (operacaoEscolhida == '5' && tela is TelaAmigo telaAmigo)
                    telaEmprestimo.Devolucao();

                else if (operacaoEscolhida == '5' && tela is TelaAmigo telaAmigo)
                    telaAmigo.VisualizarRegistrosComMultas(true);

             //   else if (operacaoEscolhida == '6' && opcaoPrincipalEscolhida == '1')
             //       telaAmigo.QuitarMulta();
                
                else if (operacaoEscolhida == '6' && tela is TelaAmigo telaAmigo)
                    telaAmigo.QuitarMulta();
            }
            Console.ReadLine();
        }

        private static void GerenciarReservas(char operacaoEscolhida, TelaReserva telaReserva)
        {
            if (operacaoEscolhida == '1')
                telaReserva.Registrar();

            else if (operacaoEscolhida == 2)
                telaReserva.RealizarEmprestimo();

            else if (operacaoEscolhida == '2')
                telaReserva.VisualizarRegistros(true);
        }

        private static void GerenciarEmprestimos(char operacaoEscolhida, TelaEmprestimo telaEmprestimo)
        {
            if (operacaoEscolhida == '1')
                telaEmprestimo.Registrar();

            if (operacaoEscolhida == '2')
                telaEmprestimo.Devolucao();

            if (operacaoEscolhida == '3')
                telaEmprestimo.VisualizarRegistros(true);
        }
    }
}

