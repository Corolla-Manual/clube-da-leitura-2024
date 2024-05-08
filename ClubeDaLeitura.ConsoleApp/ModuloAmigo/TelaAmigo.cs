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
                    amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco, amigo.Multa.MultaAberta
                );
            }

            Console.ReadLine();
            Console.WriteLine();
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

        public void CadastrarEntidadeTeste()
        {
            Amigo amigo = new Amigo("Roberto", "Luis", "49999657372", "Rua Correia Pinto");
            repositorio.Cadastrar(amigo);

            Amigo amigo2 = new Amigo("Carlos", "Leandro", "49987452136", "Rua Belizário Ramos");
            repositorio.Cadastrar(amigo2);
        }
    }
}
