using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInjection.DependenciaDebil
{
    internal class SoldadoDI
    {

        private readonly IVehiculo _vehiculo;
        private readonly IArma _arma;
        public SoldadoDI(IVehiculo vehiculo, IArma arma)
        {
            _vehiculo = vehiculo;
            _arma = arma;
        }
        public SoldadoDI(IVehiculo vehiculo)
        {
            _vehiculo = vehiculo;
        }

        public SoldadoDI(IArma arma)
        {
            _arma = arma;
        }

        public string Acelerar()
        {
            return _vehiculo.Acelerar();
        }
        public string Frenar()
        {
            return _vehiculo.Frenar();
        }

        public string Disparar()
        {
            return _arma.Disparar();
        }
        public string Recargar()
        {
            return _arma.Recargar();
        }

        //Crea la inyeccion en SoldadoDI para que
        //pueda Disparar y Cargar , una pistola y una escopeta (IArma)



    }
}
