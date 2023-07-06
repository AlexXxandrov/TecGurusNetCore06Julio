using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecGurusWeb.Model;
using EF = TecGurusWeb.EFDBFirstExample;

namespace TecGurusWeb.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly EF.DBContextDBFirst _dBContextDBFirst;

        public IndexModel(EF.DBContextDBFirst dBContextDBFirst)
        {
            _dBContextDBFirst = dBContextDBFirst;
        }

        #region Properties

        public List<EF.Student> ListStudents { get; set; }

        public List<StudentModel> ListStudentModel { get; set; }
        #endregion

        public void OnGet()
        {
            //FirstExample();
            //LinqExample1();
            //LinqExample2();
            //LinqExample3();

            //LambdaExample1();
            //LambdaExample2();

            JoinExample();
        }

        public void FirstExample()
        {
            ListStudents = _dBContextDBFirst.Students.ToList();
        }

        //LINQ -> tecnologia de control de datos para la gestion de la información

        public void LinqExample1()
        {
            var query = (from student in _dBContextDBFirst.Students
                         where student.Age >= 26
                         select student
                             ).ToList();
            ListStudents = query;

        }

        public void LinqExample2()
        {
            var query = (from student in _dBContextDBFirst.Students
                         orderby student.Name ascending
                         select student
                             ).ToList();
            ListStudents = query;

        }

        // Consulta en LinqExample3 de todos los alumnos con edad menor a 30 años y Isdeleted sea false , ordenados por su nombre descendentemente 
        public void LinqExample3()
        {
            var query = (from student in _dBContextDBFirst.Students
                         where student.Age < 30 && student.IsDeleted == false
                         orderby student.Name descending
                         select student
                             ).ToList();
            ListStudents = query;
        }


        //Lambda Expression -> Control de datos  "Lineas" accede directamente a las condicionales

        public void LambdaExample1()
        {
            var query = (from student in _dBContextDBFirst.Students
                         where student.Age >= 26
                         select student
                             ).ToList();

            ListStudents = _dBContextDBFirst.Students.Where(w => w.Age >= 26).ToList();

        }


        public void LambdaExample2()

        {
            var query = (from student in _dBContextDBFirst.Students
                         orderby student.Name ascending
                         select student
                             ).ToList();

            ListStudents = _dBContextDBFirst.Students.OrderBy(o => o.Name).ToList();

        }


        // Consulta en LambdaExample3 de todos los alumnos con edad menor a 30 años y Isdeleted sea false , ordenados por su nombre descendentemente 
        //el ejercicio que se realizo con Linq hacerlo con lambda
        public void LambdaExample3()
        {
            var query = (from student in _dBContextDBFirst.Students
                         where student.Age < 30 && student.IsDeleted == false
                         orderby student.Name descending
                         select student
                             ).ToList();


            var query2 = _dBContextDBFirst.Students.Where(w => w.Age < 30 && w.IsDeleted == false).OrderByDescending(o => o.Name).ThenBy(to=>to.Age).ToList();
            ListStudents = query2;
        }

        //jOIN CON LINQ
        public void JoinExample()
        {
            var query = (from student in _dBContextDBFirst.Students
                         join gropsy in _dBContextDBFirst.Groups
                         on student.GroupId equals gropsy.GroupId

                         orderby student.Name descending
                         select new StudentModel
                         {
                             StudentId= student.StudentId,
                             Name = student.Name,
                             Age = student.Age,
                             Email = student.Email,
                             NameGroup= gropsy.Name,
                             GroupId= gropsy.GroupId
                         }
                             ).ToList();

            ListStudentModel = query;
        }
    }
}
