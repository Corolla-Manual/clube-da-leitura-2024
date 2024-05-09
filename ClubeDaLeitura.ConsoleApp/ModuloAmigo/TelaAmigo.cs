using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20} | {5, -20}",
                "Id", "Nome", "Nome do Responsável", "Telefone", "Endereço", "Possui Multa Aberta"
            );

            ArrayList amigosCadastrados = repositorio.SelecionarTodos();

            foreach (Amigo amigo in amigosCadastrados)
            {
                if (amigo == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20} | {5, -20}",
                    amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco,
                    amigo.Multa.MultaAberta ? "Sim" : "Não"
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        public void VisualizarRegistrosComMultas(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20}",
                "Id", "Nome", "Nome do Responsável", "Telefone", "Endereço"
            );

            ArrayList amigosCadastrados = repositorio.SelecionarTodos();

            foreach (Amigo amigo in amigosCadastrados)
            {
                if (amigo == null)
                    continue;

                if (amigo.Multa.MultaAberta)
                    Console.WriteLine(
                        "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20}",
                        amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco
                    );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        public void QuitarMulta()
        {
            ApresentarCabecalho();

            VisualizarRegistrosComMultas(false);
            Console.Write("Digite o Id do amigo que quer quitar a multa: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Amigo amigo = (Amigo)repositorio.SelecionarPorId(idAmigo);

            amigo.Multa.MultaAberta = false;
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeresponsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeresponsavel, telefone, endereco);

            return amigo;
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
            Console.WriteLine($"5 - Visualizar {tipoEntidade}s com multa em aberto");
            Console.WriteLine($"6 - Quitar multa de {tipoEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }
        public void CadastrarEntidadeTeste()
        {
            Amigo amigo = new Amigo("Roberto", "Luis", "49999657372", "Rua Correia Pinto");
            repositorio.Cadastrar(amigo);

            Amigo amigo2 = new Amigo("Carlos", "Leandro", "49987452136", "Rua Belizário Ramos");
            repositorio.Cadastrar(amigo2);

            Amigo amigo3 = new Amigo("Clóvis", "Jonas", "49996857412", "Rua Zacarias Abel");
            repositorio.Cadastrar(amigo3);
        }
    }
}
