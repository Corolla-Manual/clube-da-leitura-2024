using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
