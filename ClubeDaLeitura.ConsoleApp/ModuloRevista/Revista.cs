using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista : EntidadeBase
    {
        public string Titulo {  get; set; }
        public int Edicao {  get; set; }
        public int AnoPublicacao {  get; set; }
        public Caixa Caixa {  get; set; }

        public Revista (string titulo, int edicao, int anoPublicacao, Caixa caixa)
        {
            Titulo = titulo;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            Caixa = caixa;
        }
    }
}
