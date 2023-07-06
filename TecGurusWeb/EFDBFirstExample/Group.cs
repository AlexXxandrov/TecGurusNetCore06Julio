using System;
using System.Collections.Generic;

namespace TecGurusWeb.EFDBFirstExample;

public partial class Group
{
    public int GroupId { get; set; }

    public string Name { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
