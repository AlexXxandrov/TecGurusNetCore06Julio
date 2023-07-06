using System.ComponentModel.DataAnnotations;

namespace TecGurusWeb.Model
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public int? Age { get; set; }
        [Required]
        public string? Name { get; set; }


        public string? Email { get; set; }

        public int GroupId { get; set; }

        public string NameGroup { get; set; } = null!;


    }
}
