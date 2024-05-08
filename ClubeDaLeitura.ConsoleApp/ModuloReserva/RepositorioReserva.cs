using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class RepositorioReserva : RepositorioBase
    {
        public void ChecaValidacaoReservas()
        {
            foreach (Reserva reservas in registros)
            {
                if (DateTime.Now > reservas.DataLimite)
                {
                    reservas.Expirado = true;
                }
            }
        }
    }
}
