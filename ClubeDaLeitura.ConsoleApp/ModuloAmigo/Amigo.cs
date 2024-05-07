using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class Amigo : EntidadeBase
    {
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public Multa Multa { get; set; }

        public Amigo(string nome, string nomeresponsavel, string telefone, string endereco, Multa multa)
        {
            Nome = nome;
            NomeResponsavel = nomeresponsavel;
            Telefone = telefone;
            Endereco = endereco;
            Multa = multa;
        }
    }
}
