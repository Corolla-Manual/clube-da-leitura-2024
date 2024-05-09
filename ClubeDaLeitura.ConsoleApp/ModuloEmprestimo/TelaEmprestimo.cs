using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        public TelaAmigo telaAmigo = null;
        public TelaRevista telaRevista = null;
        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Emprestimos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20} | {5, -20}",
                "Id", "Data de Empréstimo", "Data de Devolução", "Amigo", "Revista", "Concluido"
            );

            ArrayList emprestimosCadastradas = repositorio.SelecionarTodos();

            foreach (Emprestimo emprestimo in emprestimosCadastradas)
            {
                if (emprestimo == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3,-20} | {4, -20}",
                    emprestimo.Id, emprestimo.DataEmprestimo.ToShortDateString(),
                    emprestimo.DataDevolucao.ToShortDateString(), emprestimo.Amigo.Nome, emprestimo.Revista.Titulo,
                    emprestimo.Concluido ? "Sim" : "Nâo"
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        protected override EntidadeBase ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);
            Console.WriteLine("Digite o ID do Amigo: ");
            int idAmigo = int.Parse(Console.ReadLine());
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);
            Console.WriteLine("Digite o ID da Revista: ");
            int idRevista = int.Parse(Console.ReadLine());
            Revista revista = (Revista)repositorioRevista.SelecionarPorId(idRevista);

            Emprestimo emprestimo = new Emprestimo(amigo, revista);

            return emprestimo;
        }
        public void CadastrarEntidadeTeste()
        {
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPorId(1);
            Revista revista = (Revista)repositorioRevista.SelecionarPorId(1);
            Emprestimo emprestimo = new Emprestimo(amigo, revista);
            repositorio.Cadastrar(emprestimo);
            ValidaRevistaEmprestada(emprestimo);

            Amigo amigo2 = (Amigo)repositorioAmigo.SelecionarPorId(2);
            Revista revista2 = (Revista)repositorioRevista.SelecionarPorId(2);
            Emprestimo emprestimo2 = new Emprestimo(amigo2, revista2);
            emprestimo2.DataDevolucao = DateTime.Parse("05/05/2024");
            repositorio.Cadastrar(emprestimo2);
            ValidaRevistaEmprestada(emprestimo2);
        }
        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando Emprestimo...");

            Console.WriteLine();

            Emprestimo emprestimo = (Emprestimo)ObterRegistro();

            if (emprestimo.Amigo.Multa.MultaAberta)
            {
                ExibirMensagem($"O amigo {emprestimo.Amigo.Nome} esta com uma multa em aberto!", ConsoleColor.Red);
                return;
            }

            ArrayList erros = emprestimo.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            if (emprestimo.Revista.Emprestado)
            {
                ExibirMensagem($"A revista {emprestimo.Revista.Titulo} já esta emprestada!", ConsoleColor.Red);
                return;
            }

            ValidaRevistaEmprestada(emprestimo);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }
        public void ChecaValidadeMultas()
        {
            RepositorioEmprestimo repositorioEmprestimo = (RepositorioEmprestimo)repositorio;
            repositorioEmprestimo.ValidaDataLimiteEmprestimo();
        }
        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Visualizar todos os {tipoEntidade}s");
            Console.WriteLine($"3 - Visualizar todos os {tipoEntidade}s do dia");
            Console.WriteLine($"4 - Visualizar todos os {tipoEntidade}s do mês");
            Console.WriteLine($"5 - Concluir {tipoEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }
        public void Decolucao()
        {

        }
        private void ValidaRevistaEmprestada(Emprestimo emprestimo)
        {
            emprestimo.Revista.Emprestado = true;
            repositorioRevista.SelecionarPorId(emprestimo.Revista.Id).AtualizarRegistro(emprestimo.Revista);
            repositorio.Cadastrar(emprestimo);
        }


    }
}
