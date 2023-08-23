using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafe
{
    public class MaquinaDeCafeFixture : IDisposable
    {
        public MaquinaDeCafe maquinaVacia;
        public MaquinaDeCafe maquinaLlena;

        public MaquinaDeCafeFixture()
        {
            maquinaLlena = new MaquinaDeCafe(100, 100, 100, 100, 100, new Modulos.Capuchino(), new Modulos.Chocolate(), new Modulos.Te());
            maquinaVacia = new MaquinaDeCafe();
        }

        public void Dispose()
        {
            maquinaVacia = null;
            maquinaLlena = null;
        }
    }
}
