using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class Reserva : EntidadeBase
    {
        public bool Concluido {  get; set; }
        public bool Expirado { get; set;}
        public DateTime DataEmprestimo { get; set;}
        public DateTime DataDevolucao { get; set;}
        public Amigo Amigo { get; set;}
        public Revista Revista { get; set;}

        public Reserva(bool concluido, bool expirado, DateTime dataEmprestimo, DateTime dataDevolucao, Amigo amigo, Revista revista)
        {
            Concluido = concluido;
            Expirado = expirado;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Amigo = amigo;
            Revista = revista;
        }
    }
}
