namespace TecGurusWeb.ExampleDI
{
    public class DiasService : IDiasService
    {
        public List<Dias> GetDias()
        {
            //List<Dias> listaDias = new List<Dias>();
            //Dias Lunes = new Dias();
            //Lunes.Id = 1;
            //Lunes.Nombre = "LUNES";
            //listaDias.Add(Lunes);

            List<Dias> listaDias = new List<Dias>
            {
                new Dias{Id=1,Nombre="Lunes" },
                new Dias{Id=2,Nombre="Martes" },
                new Dias{Id=3,Nombre="Miercoles" },
                new Dias{Id=4,Nombre="Jueves" },
                new Dias{Id=5,Nombre="Viernes" },
                new Dias{Id=6,Nombre="Sabado" },
                new Dias{Id=7,Nombre="Domingo" },
            };

            return listaDias;
        }
    }
}
