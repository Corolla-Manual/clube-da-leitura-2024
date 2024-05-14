using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase<Revista>, ITelaCadastravel
    {
        public TelaCaixa telaCaixa = null;
        public RepositorioCaixa repositorioCaixa = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Revistas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3,-20} | {4,-20} | {5,-10}",
                "Id", "Título", "Edição", "Ano de publicação", "Caixa", "Emprestado"
            );

            List<Revista> revistasCadastradas = repositorio.SelecionarTodos();

            foreach (Revista revista in revistasCadastradas)
            {
                if (revista == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3,-20} | {4, -20} | {5,-10}",
                    revista.Id, revista.Titulo, revista.Edicao, revista.AnoPublicacao, revista.Caixa.Etiqueta,
                    revista.Emprestado ? "Sim" : "Não"
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        protected override Revista ObterRegistro()
        {
            Console.Write("Digite o titulo da revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a edição da revista: ");
            
            int edicao = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de publicação da revista: ");
            int dias = int.Parse(Console.ReadLine());

            telaCaixa.VisualizarRegistros(false);

            Console.Write("Digite o ID da caixa que deseja colocar a revista: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = (Caixa)repositorioCaixa.SelecionarPorId(idCaixa);

            Revista revista = new Revista(titulo, edicao, dias, caixa);

            caixa.Revista.Add(revista);
            repositorioCaixa.SelecionarPorId(idCaixa).AtualizarRegistro(caixa);

            return revista;
        }

        public void CadastrarEntidadeTeste()
        {
            Caixa caixa = (Caixa)repositorioCaixa.SelecionarPorId(1);
            Revista revista = new Revista("Spider Man", 1, 1980, caixa);
            caixa.Revista.Add(revista);
            repositorio.Cadastrar(revista);

            Caixa caixa2 = (Caixa)repositorioCaixa.SelecionarPorId(2);
            Revista revista2 = new Revista("Batman", 1, 1982, caixa2);
            caixa2.Revista.Add(revista2);
            repositorio.Cadastrar(revista2);

            Revista revista3 = new Revista("Homen de Ferro", 1, 1981, caixa);
            caixa.Revista.Add(revista3);
            repositorio.Cadastrar(revista3);
        }
    }
}
