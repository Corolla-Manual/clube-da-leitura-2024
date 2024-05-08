﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Caixas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3,-20} | {4,-24}",
                "Id", "Etiqueta", "Cor", "Dias de empréstimo", "Quantidade de Revistas"
            );

            ArrayList caixasCadastradas = repositorio.SelecionarTodos();

            foreach (Caixa caixa in caixasCadastradas)
            {
                if (caixa == null)
                    continue;
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3,-20} | {4, -15}",
                    caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.DiasEmprestimo, caixa.Revista.Count
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome da etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite quantos dias de empréstimo terá: ");
            int dias = int.Parse(Console.ReadLine());

            Caixa caixa = new Caixa(etiqueta, cor, dias);

            return caixa;
        }

        public void CadastrarEntidadeTeste()
        {
            Caixa medicamento = new Caixa("HQ Marvel", "Vermelho", 5);
            repositorio.Cadastrar(medicamento);
        }
    }
}

