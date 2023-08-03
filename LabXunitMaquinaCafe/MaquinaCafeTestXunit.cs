using System;
using Xunit;
using MaquinaCafe;

namespace LabXunitMaquinaCafe
{
    public class MaquinaCafeTestXunit
    {
        [Fact]
        public void Constructor_Vacio_Debe_CrearObjetoOk()
        {
            //Arrange
            MaquinaDeCafe maquina = null;

            //Actr
            maquina = new MaquinaDeCafe();

            //assert
            Assert.NotNull(maquina);
            Assert.Null(maquina.estado);
            Assert.Null(maquina.mensaje);
            Assert.InRange(maquina.Azucar, 0, 1);
            Assert.InRange(maquina.Cafe, 0, 1);
            Assert.InRange(maquina.VasosGrandes, 0, 1);
            Assert.InRange(maquina.VasosMedianos, 0, 1);
            Assert.InRange(maquina.VasosPequenios, 0, 1);
        }

        [Fact]
        public void Constructor_Parametros_Debe_CrearObjestoOk()
        {
            //Arrange
            MaquinaDeCafe maquina = null;

            //Actr
            maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //assert
            Assert.NotNull(maquina);
            Assert.NotNull(maquina.mensaje);
            Assert.NotNull(maquina.estado);
            Assert.InRange(maquina.Azucar, 1, double.MaxValue);
            Assert.InRange(maquina.Cafe, 1, double.MaxValue);
            Assert.InRange(maquina.VasosGrandes, 1, int.MaxValue);
            Assert.InRange(maquina.VasosMedianos, 1, int.MaxValue);
            Assert.InRange(maquina.VasosPequenios, 1, int.MaxValue);
        }

        [Fact]
        public void ServirCafe_PedirCafe_Debe_RegresaTrue()
        {
            //Arrange
            MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquina.servirCafe(10);

            //Assert
            Assert.True(response);
        }

        [Fact]
        public void ServirAzucar_Seleccionar_Debe_RegresarTrue()
        {
            //Arrange
            MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquina.seleccionarAzucar(10);

            //Assert
            Assert.True(response);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void SeleccionarVaso_Seleccionar_Debe_RegresarTrue( int tipoVaso )
        {
            //Arrange
            MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquina.seleccionarVaso(tipoVaso);

            //Assert
            Assert.True(response);
        }

    }
}
