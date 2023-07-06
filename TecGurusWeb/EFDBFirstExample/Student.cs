using System;
using System.Collections.Generic;

namespace TecGurusWeb.EFDBFirstExample;

public partial class Student
{
    public int StudentId { get; set; }

    public int? Age { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? GroupId { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Group? Group { get; set; }
}
