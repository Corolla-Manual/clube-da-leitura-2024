﻿namespace ClubeDaLeitura.ConsoleApp.ModuloMulta
{
    internal class Multa
    {
        public double Valor { get; set; }
        public bool MultaAberta { get; set; }

        public bool Pago { get; set; }
        public Multa()
        {
            Valor = 5;
            Pago = false;
            MultaAberta = false;
        }
    }
}
