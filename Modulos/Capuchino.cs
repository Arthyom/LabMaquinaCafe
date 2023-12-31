﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modulos
{
    [ExcludeFromCodeCoverage]

    public class Capuchino : IModulo
    {

        public double Temperatura { get; set; }

        public string Tipo { get; set; }

        public string Estado { get; set; }

        public double CantidadCapsula { get; set; }

        public IModulo Servir(double cantidad)
        {

            if (cantidad > 0 && CantidadCapsula >= cantidad)
            {
                CantidadCapsula -= cantidad;

                return new Capuchino() { Tipo = Tipo, Temperatura = Temperatura, Estado = Estado };
            }
            else
            {
                throw new Exception("no hay suficiente cantidad en la capsula");
            }
        }

        public void Seleccionar(string tipo)
        {
            double temperatura = 0.0;

            switch (tipo)
            {
                case "muy frio": temperatura = -20.00; break;
                case "frio": temperatura = 10.00; break;
                case "tibio": temperatura = 50.00; break;
                case "caliente": temperatura = 90.00; break;
                case "muy caliente": temperatura = 120.00; break;

                default: throw new Exception("tipo no definido");
            }


            Tipo = tipo; Estado = "ok"; Temperatura = temperatura;
        }

        public bool RecargarCapsula(double nuevaCantidad)
        {
            if (nuevaCantidad > 0)
            {
                CantidadCapsula = nuevaCantidad;
                return true;
            }

            return false;
        }
    }
}
