using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal class TelaPrincipal
    {
        private RepositorioAmigo repositorioAmigo;
        private TelaAmigo telaAmigo;

        private RepositorioCaixa repositorioCaixa;
        private TelaCaixa telaCaixa;

        private RepositorioRevista repositorioRevista;
        private TelaRevista telaRevista;

        private RepositorioReserva repositorioReserva;
        private TelaReserva telaReserva;

        private RepositorioEmprestimo repositorioEmprestimo;
        private TelaEmprestimo telaEmprestimo;

        public TelaPrincipal()
        {
            //Incialização Amigo
            repositorioAmigo = new RepositorioAmigo();

            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.tipoEntidade = "Amigo";
            telaAmigo.repositorio = repositorioAmigo;
            telaAmigo.CadastrarEntidadeTeste();

            //Inicialização Caixa
            repositorioCaixa = new RepositorioCaixa();

            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;
            telaCaixa.CadastrarEntidadeTeste();

            //Inicialização Revista
            repositorioRevista = new RepositorioRevista();

            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorio = repositorioRevista;
            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.CadastrarEntidadeTeste();

            //Inicialização Empréstimo
            repositorioEmprestimo = new RepositorioEmprestimo();

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Empréstimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;
            telaEmprestimo.telaRevista = telaRevista;
            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.CadastrarEntidadeTeste();

            //Inicialização Reserva
            repositorioReserva = new RepositorioReserva();

             telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.telaRevista = telaRevista;
            telaReserva.telaAmigo = telaAmigo;
            telaReserva.repositorio = repositorioReserva;
            telaReserva.repositorioRevista = repositorioRevista;
            telaReserva.repositorioAmigo = repositorioAmigo;
            telaReserva.repositorioEmprestimo = repositorioEmprestimo;
            telaReserva.CadastrarEntidadeTeste();
        }

        public ITelaCadastravel ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube de Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerenciamento de Amigos");
            Console.WriteLine("2 - Gerenciamento de Caixas");
            Console.WriteLine("3 - Gerenciamento de Revistas");
            Console.WriteLine("4 - Gerenciamento de Reservas");
            Console.WriteLine("5 - Gerenciamento de Empréstimo");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoPrincipalEscolhida = Console.ReadLine()[0];

            ITelaCadastravel tela = null;

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

            return tela;
        }
    }
}
