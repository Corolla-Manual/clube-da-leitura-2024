using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class Reserva : EntidadeBase
    {
        public bool Expirado { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataLimite { get; set; }
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }

        public Reserva(Amigo amigo, Revista revista)
        {
            Expirado = false;
            DataReserva = DateTime.Now;
            DataLimite = DataReserva.AddDays(2);
            Amigo = amigo;
            Revista = revista;
        }
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

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
            this.DataReserva = novasInformacoes.DataReserva;
            this.DataLimite = novasInformacoes.DataLimite;
            this.Amigo = novasInformacoes.Amigo;
            this.Revista = novasInformacoes.Revista;
        }
    }
}
