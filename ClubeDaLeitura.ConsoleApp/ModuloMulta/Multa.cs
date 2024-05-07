using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloMulta
{
    internal class Multa : EntidadeBase
    {
        public double Valor { get; set; }
        public bool EstaPago { get; set; }

        public Multa(double valor, bool estapago)
        {
            Valor = valor;
            EstaPago = estapago;
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
