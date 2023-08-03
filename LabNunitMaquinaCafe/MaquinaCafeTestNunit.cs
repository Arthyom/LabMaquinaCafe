using MaquinaCafe;
using NUnit.Framework;

namespace LabNunitMaquinaCafe
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
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
            Assert.AreEqual(maquina.Azucar, 0);
            Assert.AreEqual(maquina.Cafe, 0);
            Assert.AreEqual(maquina.VasosGrandes, 0);
            Assert.AreEqual(maquina.VasosMedianos, 0);
            Assert.AreEqual(maquina.VasosPequenios, 0);
        }

        [Test]
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
            Assert.AreEqual(maquina.Azucar, 100);
            Assert.AreEqual(maquina.Cafe, 1000);
            Assert.AreEqual(maquina.VasosGrandes, 10);
            Assert.AreEqual(maquina.VasosMedianos, 10);
            Assert.AreEqual(maquina.VasosPequenios, 10);
        }

        [Test]
        public void ServirCafe_PedirCafe_Debe_RegresaTrue()
        {
            //Arrange
            MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquina.servirCafe(10);

            //Assert
            Assert.True(response);
        }

        [Test]
        public void ServirAzucar_Seleccionar_Debe_RegresarTrue()
        {
            //Arrange
            MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = maquina.seleccionarAzucar(10);

            //Assert
            Assert.True(response);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SeleccionarVaso_Seleccionar_Debe_RegresarTrue(int tipoVaso)
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