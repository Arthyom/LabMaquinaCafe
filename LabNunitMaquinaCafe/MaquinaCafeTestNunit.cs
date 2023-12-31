using AutoFixture;
using AutoFixture.AutoMoq;
using MaquinaCafe;
using Modulos;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace LabNunitMaquinaCafe
{
    [SetUpFixture]
    public class SetUpClass
    {
        protected Fixture _fixture;
        protected MaquinaDeCafe cafeteraVacia;
        protected MaquinaDeCafe cafeteraLlena;

        /// mocking de una propiedad
        public Mock<IModulo> mockModuloCapuchino = new Mock<IModulo>();
        public Mock<IModulo> mockModuloChocolate = new Mock<IModulo>();
        public Mock<Te> mockModuloTe = new Mock<Te>();

        /// repositorio para centralizar los mocks 
        public MockRepository repoMock = new MockRepository(MockBehavior.Default);

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

            //Creando autofixtures con un constructor con parametros
            //var fixture2 = new Fixture();
            //fixture2.Register(() => new MaquinaDeCafe(100, 100, 100, 100, 100, new Capuchino()));

            //Creacion de un autofixture de la forma mas simple
            //cafeteraVacia = _fixture.Create<MaquinaDeCafe>();
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

        #region metodos sin uso
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
        #endregion
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
            //  Codigo heredado que usa una instacia directa del modulo de capuchino
            //cafeteraLlena = new MaquinaDeCafe(3, 3, 3, 3, 3, new Modulos.Capuchino());

            cafeteraLlena = new MaquinaDeCafe
                (3, 3, 3, 3, 3, mockModuloCapuchino.Object, mockModuloChocolate.Object, mockModuloTe.Object);
        }

        /// <summary>
        /// Codigo que sera reutilizado solo una vez
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        #region Metodos ya provados
        [Test]
        [Ignore("Razon")]
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
        [Ignore("Razon")]

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
            bool response = cafeteraLlena.servir(3);

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
        #endregion Metodos ya provados

        [Test]
        public void Servir_ServirCapuchino_Debe_RegresarCapuchino()
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe();

            //Usando una verificacion explicita
            //mockModuloCapuchino.Setup(mock => mock.Servir(It.IsAny<double>())).Returns(new Capuchino() { Estado = "ok"});
            //mockModuloChocolate.Setup(mock => mock.Servir(It.IsAny<double>())).Returns(new Capuchino() { Estado = "ok" });

            //Usando una verificacion implicita}

            //Comentado para usar el mock repo
            //mockModuloCapuchino.Setup(mock => mock.Servir(It.IsAny<double>()))
            //    .Callback((double x) => TestContext.Progress.WriteLine($"ejecutando codigo despues del setup cuando se sirve capuchino {x}"))
            //    .Returns(new Capuchino() { Estado = "ok" })
            //    .Verifiable();

            //mockModuloChocolate.Setup(mock => mock.Servir(It.IsAny<double>()))
            //    .Callback((double x) =>
            //    {
            //        TestContext.Progress.WriteLine($"ejecutando codigo despues del setup cuando se sirve chocolate {x}");
            //        //if (x >= 10) throw new Exception("Error controlado por un callback");
            //    })

            //    .Returns(new Chocolate() { Estado = "ok" })
            //    .Verifiable();


            //mockModuloTe.Setup(mock => mock.Servir(It.IsAny<double>()))
            //    .Callback((double x) => TestContext.Progress.WriteLine($"ejecutando codigo despues del setup cuando se sirve capuchino {x}"))
            //    .Returns(new Capuchino() { Estado = "ok" })
            //    .Verifiable();

            var mCap = repoMock.Create<IModulo>();
            mCap.Setup((mock) => mock.Servir(It.IsAny<double>())).Returns(new Capuchino() { Estado = "ok" });

            var mCho = repoMock.Create<Chocolate>();
            mCho.Setup((mock) => mock.Servir(It.IsAny<double>())).Returns(new Chocolate() { Estado = "ok" });

            var mTe = repoMock.Create<Te>();
            mTe.Setup((mock) => mock.Servir(It.IsAny<double>())).Returns(new Te() { Estado = "ok" });



            cafeteraLlena = new MaquinaDeCafe
               (3, 3, 3, 3, 3, mCap.Object, mCho.Object, mTe.Object);

            //Act
            cafeteraLlena.servirCapuchino(10.0);
            cafeteraLlena.servirChocolate(10.0);
            cafeteraLlena.servirTe(10.0);



            //Assert
            //Verificacion explicita
            //mockModuloCapuchino.Verify(mock => mock.Servir(It.IsAny<double>()), Times.Once);

            //Verificacion implicita
            //mockModuloCapuchino.Verify();
            //mockModuloChocolate.Verify();

            //Verificacion implicita via mock
            Mock.VerifyAll();
            Mock.Verify(mockModuloCapuchino, mockModuloChocolate, mockModuloTe);

            Assert.That(cafeteraLlena.estado, Is.EqualTo("ok"));
            Assert.That(cafeteraLlena.VasosGrandes, Is.LessThan(3));


        }

        [Test]
        public void Servir_ServirCapuchino_Debe_RegresarError()
        {
            //Codigo centralizado
            //Arrange
            //MaquinaDeCafe maquina = new MaquinaDeCafe();
            mockModuloCapuchino.Invocations.Clear();
            mockModuloCapuchino.Setup(mock => mock.Servir(It.IsAny<double>())).Throws(new Exception());

            //Act
            Assert.Throws<Exception>(() => cafeteraLlena.servirCapuchino(10.0));

            //Assert
            mockModuloCapuchino.Verify(mock => mock.Servir(It.IsAny<double>()), Times.Once);
        }

        [Test]
        public void SeleccionarCapuchino_Seleccionar_Debe_FijarValores()
        {
            //Codigo centralizado
            //Arrange
            // mockModuloCapuchino.SetupGet(mock => mock.CantidadCapsula).Returns(10);
            //mockModuloCapuchino.SetupGet(mock => mock.Tipo).Returns("capuchino helado");

            //mockModuloCapuchino.SetupProperty(mock => mock.Tipo, "algo");
            //mockModuloCapuchino.SetupProperty(mock => mock.CantidadCapsula, 34);

            mockModuloCapuchino.SetupAllProperties();

            // mockModuloCapuchino.SetupSet(mock => mock.Temperatura = It.IsAny<double>())
            //.Verifiable(Times.Never);
            ;


            cafeteraLlena._moduloCapuchino.Tipo = "caliente";
            cafeteraLlena._moduloCapuchino.CantidadCapsula = 69;


            //Act
            cafeteraLlena.seleccionarTipoCapuchino("frio");

            //mockModuloCapuchino.Object.Tipo = "caliente";


            Assert.True(cafeteraLlena._moduloCapuchino.Tipo.Equals("caliente"));

            //Assert
            //Assert.True(cafeteraLlena._moduloCapuchino.CantidadCapsula > 0);
            //Assert.True(cafeteraLlena._moduloCapuchino.Tipo.Any());


            //mockModuloCapuchino.VerifyGet(mock => mock.CantidadCapsula, Times.Once);
            //mockModuloCapuchino.VerifySet(mock => mock.Temperatura = It.IsAny<double>());

            //mockModuloCapuchino.Verify();

            //mockModuloCapuchino.Verify(mock => mock.Seleccionar(It.IsAny<string>()), Times.Once);
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