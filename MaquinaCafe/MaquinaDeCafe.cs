using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafe
{
    public class MaquinaDeCafe
    {
        #region Propiedades
        private double cafe;

        private int vasosPequenios;

        private int vasosMedianos;

        private int vasosGrandes;

        private double azucar;


        public int VasosPequenios { get { return vasosPequenios; } }

        public int VasosMedianos { get { return vasosMedianos; } }

        public int VasosGrandes { get { return vasosGrandes; } }

        public double Azucar { get { return azucar; } }

        public double Cafe { get { return cafe; } }


        public string mensaje { get; set; }

        public string estado { get; set; }
        #endregion Propiedades

        #region Constructor de la clase
        public MaquinaDeCafe() { }

        public MaquinaDeCafe(double azucarInicial, double cafeInicial, int vasosPequeniosInicial, int vasosMedianosInicial, int vasosGrandesInicial)
        {
            azucar = azucarInicial;
            cafe = cafeInicial;
            vasosPequenios = vasosPequeniosInicial;
            vasosMedianos = vasosMedianosInicial;
            vasosGrandes = vasosGrandesInicial;
            mensaje = "ok. listo";
            estado = "ok";
        }
        #endregion 

        #region Metodos publicos
        public bool seleccionarVaso(int tipoVasoSeleccionado)
        {
            if (hayVasos())
            {
                switch (tipoVasoSeleccionado)
                {
                    // vaso chico
                    case 1:
                        if (hayVaso(tipoVasoSeleccionado))
                        {
                            fijarEstadoyMensaje("ok", "vaso chico seleccionado");
                            vasosPequenios--;
                        }
                        return true;

                    // vaso mediano
                    case 2:
                        if (hayVaso(tipoVasoSeleccionado))
                        {
                            fijarEstadoyMensaje("ok", "vaso mediano seleccionado");
                            vasosMedianos--;
                        }
                        return true;

                    // vaso grandes
                    case 3:
                        if (hayVaso(tipoVasoSeleccionado))
                        {
                            fijarEstadoyMensaje("ok", "vaso grande seleccionado");
                            vasosGrandes--;
                        }
                        return true;

                    default:
                        throw new Exception("Error. Vaso no existe");
                }
            }
            else
            {
                throw new Exception("Error no hay vasos");
            }
        }

        public bool seleccionarAzucar(double azucarSeleccionada)
        {
            if (azucar >= azucarSeleccionada)
            {
                fijarEstadoyMensaje("ok", "azucar correcta");
                azucar -= azucarSeleccionada;
                return true;
            }

            fijarEstadoyMensaje("ok", "no hay suficiente azucar");
            return false;
        }

        public bool servirCafe(int cantidadCafe)
        {
            if (cafe > 0 && cafe >= cantidadCafe)
            {
                fijarEstadoyMensaje("Ok", "orden correcta");
                cafe -= cantidadCafe;
                return true;
            }
            else
            {
                throw new Exception("Error. no hay suficiente cafe");
            }
        }
        #endregion Metodos publicos

        #region Metodos privados
        private bool hayVasos()
        {
            
            if (vasosGrandes > 0 && vasosMedianos > 0 && vasosPequenios > 0)
            {
                fijarEstadoyMensaje("Ok", "vasos suficientes");
                return true;
            }
            return false;
        }

        private bool hayVaso(int tipoVaso)
        {
            switch (tipoVaso)
            {
                // vaso pequenio
                case 1:
                    if (vasosPequenios > 0)
                    {
                        fijarEstadoyMensaje("Ok", "vasos chicos suficientes");
                        return true;
                    }
                    break;

                // vaso mediano
                case 2:
                    if (vasosMedianos > 0)
                    {
                        fijarEstadoyMensaje("Ok", "vasos medianos suficientes");
                        return true;
                    }
                    break;

                // vaso pequenio
                case 3:
                    if (vasosGrandes > 0)
                    {
                        fijarEstadoyMensaje("Ok", "vasos grandes suficientes");
                        return true;
                    }
                    break;
            }

            throw new Exception("Error. No hay vasos del tipo seleccionado");
        }

        private void fijarEstadoyMensaje(string estadoActual, string mensajeActual)
        {
            estado = estadoActual;
            mensaje = mensajeActual;
        }
        #endregion Metodos Privados
    }
}
