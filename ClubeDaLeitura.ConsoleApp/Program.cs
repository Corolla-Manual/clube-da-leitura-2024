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
                ITelaCadastravel tela = telaPrincipal.ApresentarMenuPrincipal();

                telaEmprestimos.ChecaValidadeMultas();
                telaReservas.ChecaValidadeReserva();

                if (tela == null)
                    break;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (tela is TelaEmprestimo telaEmprestimo)
                    GerenciarEmprestimos(operacaoEscolhida, telaEmprestimo);

                else if (tela is TelaReserva telaReserva)
                    GerenciarReservas(operacaoEscolhida, telaReserva);

                else if (tela is TelaAmigo telaAmigo)
                    GerenciarAmigos(operacaoEscolhida, telaAmigo);

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

        private static void GerenciarReservas(char operacaoEscolhida, TelaReserva telaReserva)
        {
            if (operacaoEscolhida == '1')
                telaReserva.Registrar();

            else if (operacaoEscolhida == '3')
                telaReserva.RealizarEmprestimo();

            else if (operacaoEscolhida == '2')
                telaReserva.VisualizarRegistros(true);
        }

        private static void GerenciarEmprestimos(char operacaoEscolhida, TelaEmprestimo telaEmprestimo)
        {
            if (operacaoEscolhida == '1')
                telaEmprestimo.Registrar();

            if (operacaoEscolhida == '5')
                telaEmprestimo.Devolucao();

            if (operacaoEscolhida == '2')
                telaEmprestimo.VisualizarRegistros(true);

            if (operacaoEscolhida == '3')
                telaEmprestimo.VisualizarRegistrosDoDia(true);

            if (operacaoEscolhida == '4')
                telaEmprestimo.VisualizarRegistrosDoMes(true);
        }

        private static void GerenciarAmigos(char operacaoEscolhida, TelaAmigo telaAmigo)
        {
            if (operacaoEscolhida == '1')
                telaAmigo.Registrar();

            if (operacaoEscolhida == '2')
                telaAmigo.Editar();

            if (operacaoEscolhida == '3')
                telaAmigo.Excluir();

            if (operacaoEscolhida == '4')
                telaAmigo.VisualizarRegistros(true);

            if (operacaoEscolhida == '5')
                telaAmigo.VisualizarRegistrosComMultas(true);

            if (operacaoEscolhida == '6')
                telaAmigo.QuitarMulta();
        }
    }
}

