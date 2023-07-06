using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInjection.DependenciaDebil
{
    internal class TanqueDI : IVehiculo
    {
        public string Acelerar()
        {
            return "Acelerando Tanque";
        }

        public string Frenar()
        {
            return "Frenando Tanque";
        }
    }
}
