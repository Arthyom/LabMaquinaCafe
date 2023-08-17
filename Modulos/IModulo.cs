using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos
{
    public interface IModulo
    {
        double Temperatura { get; set; }

        string Tipo { get; set; }

        string Estado { get; set; }

        double CantidadCapsula { get; set; }

        bool RecargarCapsula(double nuevaCantidad);

        void Seleccionar(string tipo);

        IModulo Servir(double cantidad);
    }
}
