using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInjection.DependenciaDebil
{
    internal class Pistola : IArma
    {
        public string Disparar()
        {
            return "Disparando Pistola";
        }
        public string Recargar()
        {
            return "Recargando Pistola";
        }
    }
}
