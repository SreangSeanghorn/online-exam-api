using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Tiltle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Credits { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
