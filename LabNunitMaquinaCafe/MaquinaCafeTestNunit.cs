using AutoFixture;
using MaquinaCafe;
using NUnit.Framework;
using System;

namespace LabNunitMaquinaCafe
{
    [SetUpFixture]
    public class SetUpClass
    {
        protected MaquinaDeCafe cafeteraVacia;
        protected MaquinaDeCafe cafeteraLlena;

        public SetUpClass()
        {
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
            cafeteraVacia = fixture2.Create<MaquinaDeCafe>();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestContext.Progress.WriteLine("One Time SetUp desde la clase setup");
            cafeteraVacia = new MaquinaDeCafe();
        }

        [OneTimeTearDown]
        public void OnetimeTearDown()
        {
            TestContext.Progress.WriteLine("One Time Tear Down desde la clase setup");
        }

        /*
         * Metodos no permitidos en setupfixture
        [SetUp]
        public void SetUp()
        {
            TestContext.Progress.WriteLine("Set up ejecutado desde la clase heredada");
            cafeteraLlena = new MaquinaDeCafe(10, 10, 10, 10, 10);
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("Tear down ejecutadose desde la clase heredada");
            cafeteraLlena = null;
        }
        */
    }

    [TestFixture]
    public class Tests : SetUpClass
    {

        //private MaquinaDeCafe cafeteraVacia;
        //private MaquinaDeCafe cafeteraLlena;

        /// <summary>
        /// Constructor de la clase que sera ejecutado antes que todo
        /// </summary>
        public Tests()
        {
          //  Codigo heredado 
          //  cafeteraVacia = new MaquinaDeCafe();
        }

        /// <summary>
        /// Codigo que sera reutilizado antes de cualquier prueba
        /// </summary>
        [SetUp]
        public void Setup()
        {
            //  Codigo heredado 
            cafeteraLlena = new MaquinaDeCafe(3, 3, 3, 3, 3);


        }

        /// <summary>
        /// Codigo que sera reutilizado solo una vez
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        [Test]
        public void Constructor_Vacio_Debe_CrearObjetoOk()
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = null;

            //Actr
            //maquina = new MaquinaDeCafe();

            //assert
            Assert.NotNull(cafeteraVacia);
            Assert.Null(cafeteraVacia.estado);
            Assert.Null(cafeteraVacia.mensaje);
            Assert.AreEqual(cafeteraVacia.Azucar, 0);
            Assert.AreEqual(cafeteraVacia.Cafe, 0);
            Assert.AreEqual(cafeteraVacia.VasosGrandes, 0);
            Assert.AreEqual(cafeteraVacia.VasosMedianos, 0);
            Assert.AreEqual(cafeteraVacia.VasosPequenios, 0);
        }

        [Test]
        public void Constructor_Parametros_Debe_CrearObjestoOk()
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = null;

            //Actr
            //maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //assert
            Assert.NotNull(cafeteraLlena);
            Assert.NotNull(cafeteraLlena.mensaje);
            Assert.NotNull(cafeteraLlena.estado);
            Assert.AreEqual(cafeteraLlena.Azucar, 3);
            Assert.AreEqual(cafeteraLlena.Cafe, 3);
            Assert.AreEqual(cafeteraLlena.VasosGrandes, 3);
            Assert.AreEqual(cafeteraLlena.VasosMedianos, 3);
            Assert.AreEqual(cafeteraLlena.VasosPequenios, 3);
        }

        [Test]
        public void ServirCafe_PedirCafe_Debe_RegresaTrue()
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = cafeteraLlena.servirCafe(3);

            //Assert
            Assert.True(response);
        }

        [Test]
        public void ServirAzucar_Seleccionar_Debe_RegresarTrue()
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = cafeteraLlena.seleccionarAzucar(3);

            //Assert
            Assert.True(response);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SeleccionarVaso_Seleccionar_Debe_RegresarTrue(int tipoVaso)
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = cafeteraLlena.seleccionarVaso(tipoVaso);

            //Assert
            Assert.True(response);
        }

        [Test]
        [Description("Esta es una descripcion de la prueba")]
        [TestOf(typeof(MaquinaDeCafe))]
        public void SeleccionarVaso_Seleccionar_Debe_RegresarTrueConValores([Range(1, 3)] int tipoVaso)
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            bool response = cafeteraLlena.seleccionarVaso(tipoVaso);

            //Assert
            Assert.True(response);
        }

        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void SeleccionarVaso_Seleccionar_Debe_RegresarErrorSiNoHayVasos(int tipoVaso)
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe(100, 1000, 10, 10, 10);

            //Act
            Exception exp = Assert.Throws<Exception>(() => cafeteraLlena.seleccionarVaso(tipoVaso));

            //Assert
            Assert.That(exp.Message.Length >= 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SeleccionarVaso_Seleccionar_Debe_RegresarErrorSiNoHaIniciado(int tipoVaso)
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe();

            //Act
            Exception exp = Assert.Throws<Exception>(() => cafeteraVacia.seleccionarVaso(tipoVaso));

            //Assert
            Assert.That(exp.Message.Length >= 0);
        }

        /// <summary>
        /// Codigo que sera ejecutado una sola vez al final de alguna prueba
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

        /// <summary>
        /// Codigo que sera ejecutado despues de cada prueba
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            cafeteraLlena = null;
        }




    }
}