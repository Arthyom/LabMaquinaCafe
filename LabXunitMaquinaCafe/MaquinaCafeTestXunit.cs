using System;
using Xunit;
using MaquinaCafe;
using AutoFixture;

namespace LabXunitMaquinaCafe
{
    public class MaquinaCafeTestXunit:IClassFixture<MaquinaDeCafeFixture> //IDisposable
    {
        Fixture _fixture = new Fixture();
        private MaquinaDeCafe maquinaVacia;
        private MaquinaDeCafe maquinaLlena;
        private MaquinaDeCafeFixture _maquinaCafeFixture;

        public MaquinaCafeTestXunit(MaquinaDeCafeFixture maquinaDeCafeFixture)
        {

           // maquinaVacia = new MaquinaDeCafe();
           // maquinaLlena = new MaquinaDeCafe(100, 100, 100, 100, 100);
            _maquinaCafeFixture = maquinaDeCafeFixture;

            //puede generar fallo debido a la los valores esperados en las pruebas
            //cafeteraLlena = _fixture.Create<MaquinaDeCafe>();

            //Se ejecuta para todos los objetos creados a partir de esta llamada
            //_fixture.Customize<MaquinaDeCafe>(
            //   (x) => x
            //         .With(MaquinaDeCafe => MaquinaDeCafe.Azucar, 100)
            //         .With(MaquinaDeCafe => MaquinaDeCafe.Cafe, 100)
            //         .With(MaquinaDeCafe => MaquinaDeCafe.VasosGrandes, 100)
            //         .With(MaquinaDeCafe => MaquinaDeCafe.VasosMedianos, 100)
            //         .With(MaquinaDeCafe => MaquinaDeCafe.VasosPequenios, 100)
            //   );
            //cafeteraLlena = _fixture.Create<MaquinaDeCafe>();

            //produce errores dado que la propiedad no se puede asignar
            //cafeteraLlena = _fixture.Build<MaquinaDeCafe>()
            //    .With(MaquinaDeCafe => MaquinaDeCafe.Azucar, 100)
            //    .With(MaquinaDeCafe => MaquinaDeCafe.Cafe, 100)
            //    .With(MaquinaDeCafe => MaquinaDeCafe.VasosGrandes, 100)
            //    .With(MaquinaDeCafe => MaquinaDeCafe.VasosMedianos, 100)
            //    .With(MaquinaDeCafe => MaquinaDeCafe.VasosPequenios, 100)
            //    .Create();

            var fixture2 = new Fixture();
            fixture2.Register(() => new MaquinaDeCafe(100, 100, 100, 100, 100));
            maquinaLlena = fixture2.Create<MaquinaDeCafe>();
            maquinaVacia = _fixture.Create<MaquinaDeCafe>();
        }

        [Fact]
        public void Constructor_Vacio_Debe_CrearObjetoOk()
        {
            //Arrange
            //MaquinaDeCafe maquina = null;

            //Actr
            //maquinaVacia = new MaquinaDeCafe();

            //assert
            //Assert.NotNull(maquinaVacia);
            //Assert.Null(maquinaVacia.estado);
            //Assert.Null(maquinaVacia.mensaje);
            //Assert.InRange(maquinaVacia.Azucar, 0, 1);
            //Assert.InRange(maquinaVacia.Cafe, 0, 1);
            //Assert.InRange(maquinaVacia.VasosGrandes, 0, 1);
            //Assert.InRange(maquinaVacia.VasosMedianos, 0, 1);
            //Assert.InRange(maquinaVacia.VasosPequenios, 0, 1);

            Assert.InRange(_maquinaCafeFixture.maquinaVacia.VasosGrandes, 0, 1);
        }

        [Fact]
        public void Constructor_Parametros_Debe_CrearObjestoOk()
        {
            //Arrange
            //MaquinaDeCafe maquina = null;

            //Actr
            //maquinaLlena = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //assert
            //Assert.NotNull(maquinaLlena);
            //Assert.NotNull(maquinaLlena.mensaje);
            //Assert.NotNull(maquinaLlena.estado);
            //Assert.InRange(maquinaLlena.Azucar, 1, double.MaxValue);
            //Assert.InRange(maquinaLlena.Cafe, 1, double.MaxValue);
            //Assert.InRange(maquinaLlena.VasosGrandes, 1, int.MaxValue);
            //Assert.InRange(maquinaLlena.VasosMedianos, 1, int.MaxValue);
            //Assert.InRange(maquinaLlena.VasosPequenios, 1, int.MaxValue);

            Assert.InRange(_maquinaCafeFixture.maquinaLlena.VasosGrandes, 1, int.MaxValue);

        }

        [Fact]
        public void ServirCafe_PedirCafe_Debe_RegresaTrue()
        {
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquinaLlena.servirCafe(10);

            //Assert
            Assert.True(response);
        }

        [Fact]
        public void ServirAzucar_Seleccionar_Debe_RegresarTrue()
        {
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquinaLlena.seleccionarAzucar(10);

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
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquinaLlena.seleccionarVaso(tipoVaso);

            //Assert
            Assert.True(response);
        }

        [Fact]
        public void ServirCafe_MaquinaVacia_RegresaError()
        {
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe();

            //Act
            Exception response = Assert.Throws<Exception>(() => maquinaVacia.servirCafe(1));

            //Assert
            Assert.NotNull(response.Message);
        }

        public void Dispose()
        {
            maquinaVacia = null;
            maquinaLlena = null;
        }
    }
}
