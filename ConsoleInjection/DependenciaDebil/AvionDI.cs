using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInjection.DependenciaDebil
{
    internal class AvionDI : IVehiculo
    {
        public string Acelerar()
        {
            return "Acelerando Avion";
        }
        public string Frenar()
        {
            return "Frenando Avion";
        }
    }
}
