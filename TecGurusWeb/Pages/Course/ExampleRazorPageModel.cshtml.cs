using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecGurusWeb.Model;

namespace TecGurusWeb.Pages.Course
{
    /// <summary>
    /// A nivel conceptual de MV V M ExampleRazorPageModel  es -> ViewModel
    /// y a nivel POO es una clase y una clase tiene Propiedades y Metodos    
    /// /// </summary>
    /// Bindea todas las propiedades de la clase "ViewModel" son recuperables todas
    [BindProperties]
    public class ExampleRazorPageModelModel : PageModel
    {
        #region Properties
        /// <summary>
        /// Todas las propiedades colocadas en el ViewModel forman parte de Modelo para 
        /// intercomunicar datos entre la Vista y  ViewModel
        /// </summary>
        public string Mensaje { get; set; }


        public int MyId { get; set; }


        /// <summary>
        /// Los binding son intercambio de informacion entre mi modelo y mi vista
        //si no se pone el bind property no se recuperan los datos de la vista llega null
        /// </summary>
        //[BindProperty]
        public PersonaModel Persona { get; set; }

        #endregion

        //este es el metodo de recuperacion de la pagina (similar al PageLoad) 
        //El metodo puede o no recibir parametros que sirven para recuperar informacion
        // y mostrarlos a la vista
        //Es un metodo Reservado por que tiene la palabra OnGet, al igual que el OnPost para recuperar info d ela view
        public void OnGet()
        {
            //ejercicio:
            //Mesaje : h1 Hola mundo desde RazorPage "MVVM" la hora y fecha actual es:

            Mensaje = "Hola mundo desde RazorPage MVVM " + DateTime.Now.ToString();
            setPesona();
        }

        /// <summary>
        /// Metodo para Establazar 
        /// </summary>
        private void setPesona()
        {
            Persona = new PersonaModel();
            Persona.Id = 1;
            Persona.Name = "Ruben";
            Persona.Email = "ruben.alquicira@hotmail.com";
            Persona.Phone = "5869631245";
        }

        /// <summary>
        /// Metodo HTTP que recupera informacion de la Vista
        /// En este metodo recuperaremos datos por un parametro ,
        /// no por propiedad del modelo
        /// Regla; desde la vista debe especificarse tal 
        /// cual el nombre del parametro, si no llegaria Null
        /// En esta ocasion la solicitud caeria en eeste 
        /// Unico OnPost al nop tener mas metodos Post escritos
        /// </summary>
        public void OnPost(string parametroString)
        {
            var parametro = parametroString;
        }

        /// <summary>
        /// Por Regla los metodos de recuperacion les debe
        /// anteceder o tenerr como prefijo la palabra OnPost
        /// </summary>
        public void OnPostPersona()
        {
            var persona = Persona;
        }


        //En un solo formulario debajo del de persona colocar crear un nuevo form para que se digiten datos para 
        //Pais : Id, Nombre, ademas de datos para Person Nombre y el email

        /// <summary>
        /// redirigir por queryString "url" el valor a otro RazorPage
        /// </summary>
        public IActionResult OnPostRedirectParameter()
        {
            var num = MyId;

            return RedirectToPage("/ExampleRedirect/QueryString",
                new {Id=num });
        }

        [TempData]
        public string Nombre { get; set; }
        //ctrl  + m + o

        //Para pasar informacion de un Page a otro, podria ser por query string
        //pero puedo utilizar un TempData el cual me permite almacenar de manera temporal
        //informacion primitiva o string  int etc, no clases
        //definidas por mi como es persona, el valor que establesca aqui al nombre d ela propiedad se va a replicar
        //en ExampleTempData, por regla debe llamarse igual la propiedad en el otro razorPage
        //a comunicar
        //TempData -> se debe de colocar el decorador ariba de la propiedad que se enviara y tambien en la propiedad
        //que recibe el dato
        public IActionResult OnPostRedirectTempDataParameter()
        {
            Nombre = "Ruben Alquicira";
            //crearia una cadena de texto formateada a Json -> json.Serialize
            return RedirectToPage("/ExampleRedirect/ExampleTempData");
        }


        //Enterprise Library -
        // ADO .Net -Sql Client -Transact Sql (select * from Alumno...) / sp_ GetStatus
        // 100 tablas = 100 clases  - Tabla de la BDD  List<Alumno> Id Name DTO Data Transfer Object
        // Entity Framework -> Tecnologia de accesso a Datos -ORM Object Relational Mapping ->
        // CodeFirst  -> componente -> Clases crean la BDD -> add Migration ,Updata Database
        // DataBaseFirst -> algun comando incorporar las clases en relacion a una BDD existente
        // DBContext -> objeto que permite la comunicación  a la BDD tanto en CodeFirst DatabaseFirst
        //              con una cadena de conexión 

    }
}
