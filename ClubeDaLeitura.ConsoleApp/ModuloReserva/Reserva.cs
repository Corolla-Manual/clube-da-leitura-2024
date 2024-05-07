using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class Reserva : EntidadeBase
    {
        public bool Expirado { get; set;}
        public DateTime DataEmprestimo { get; set;}
        public DateTime DataDevolucao { get; set;}
        public Amigo Amigo { get; set;}
        public Revista Revista { get; set;}

        public Reserva(bool expirado, DateTime dataEmprestimo, DateTime dataDevolucao, Amigo amigo, Revista revista)
        {
            Expirado = expirado;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Amigo = amigo;
            Revista = revista;
        }
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();


            if (Expirado == null)
                erros.Add("O campo \"Expirado\" é obrigatório");

            if (DataEmprestimo == null)
                erros.Add("O campo \"DataEmprestimo\" é obrigatório");

            if (DataDevolucao == null)
                erros.Add("O campo \"DataDevolucao\" é obrigatório");

            if (Amigo == null)
                erros.Add("O campo \"Amigo\" é obrigatório");

            if (Revista == null)
                erros.Add("O campo \"Revista\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Reserva novasInformacoes = (Reserva)novoRegistro;

            this.Expirado = novasInformacoes.Expirado;
            this.DataEmprestimo = novasInformacoes.DataEmprestimo;
            this.DataDevolucao = novasInformacoes.DataDevolucao;
            this.Amigo = novasInformacoes.Amigo;
            this.Revista = novasInformacoes.Revista;
        }
    }
}
