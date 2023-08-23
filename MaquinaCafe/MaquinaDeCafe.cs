
using Modulos;
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

        private IModulo _moduloCapuchino;

        private IModulo _moduloChocolate;

        private Te _moduloTe;


        public int VasosPequenios { get { return vasosPequenios; } }

        public int VasosMedianos { get { return vasosMedianos; } }

        public int VasosGrandes { get { return vasosGrandes; } }

        public double Azucar { get { return azucar; } }

        public double Cafe { get { return cafe; } }

        public IModulo InfoModuloCapuchino { get { return _moduloCapuchino; } }


        public string mensaje { get; set; }

        public string estado { get; set; }
        #endregion Propiedades

        #region Constructor de la clase
        public MaquinaDeCafe() { }

        public MaquinaDeCafe(double azucarInicial,
                             double cafeInicial,
                             int vasosPequeniosInicial,
                             int vasosMedianosInicial,
                             int vasosGrandesInicial,
                             IModulo moduloCapuchino,
                             IModulo moduloChocolate,
                             Te moduloTe
                             )
        {
            azucar = azucarInicial;
            cafe = cafeInicial;
            vasosPequenios = vasosPequeniosInicial;
            vasosMedianos = vasosMedianosInicial;
            vasosGrandes = vasosGrandesInicial;
            mensaje = "ok. listo";
            estado = "ok";
            _moduloCapuchino = moduloCapuchino;
            _moduloChocolate = moduloChocolate;
            _moduloTe = moduloTe;

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

        public bool servir(int cantidadCafe)
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

        public IModulo servirCapuchino(double cantidadCapuchino)
        {
            try
            {
                IModulo respuesta = _moduloCapuchino.Servir(cantidadCapuchino);
                if(respuesta.Estado == "ok")
                {
                    estado = "ok";
                    mensaje = "capuchino servido";
                    vasosGrandes -= 1;
                    return respuesta;
                }
                else
                {
                    estado = "fallido";
                    mensaje = "el capuchino no se pudo servir intente otra vez";
                    return null;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al servir el capuchino");
            }
        }

        public IModulo servirChocolate(double cantidadChocolate)
        {
            try
            {
                IModulo respuesta = _moduloChocolate.Servir(cantidadChocolate);
                if (respuesta.Estado == "ok")
                {
                    estado = "ok";
                    mensaje = "chocolate servido";
                    vasosGrandes -= 1;
                    return respuesta;
                }
                else
                {
                    estado = "fallido";
                    mensaje = "el chocolate no se pudo servir intente otra vez";
                    return null;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al servir el chocolate");
            }
        }

        public Te servirTe(double cantidadTe)
        {
            try
            {
                Te respuesta =  _moduloTe.Servir(cantidadTe);
                if (respuesta.Estado == "ok")
                {
                    estado = "ok";
                    mensaje = "chocolate te";
                    vasosGrandes -= 1;
                    return respuesta;
                }
                else
                {
                    estado = "fallido";
                    mensaje = "el te no se pudo servir intente otra vez";
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al servir el te");
            }
        }

        public void seleccionarTipoCapuchino(string tipoCapuchino)
        {
            try
            {
                _moduloCapuchino.Seleccionar(tipoCapuchino);

                if (_moduloCapuchino.Tipo.Any())
                {
                    estado = "ok";
                    mensaje = "tipo de capuchino seleccionado";
                }
                else
                {
                    estado = "fallido";
                    mensaje = "no se puede seleccionar intente mas tarde";
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al seleccionar el tipo de capuchino");
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
