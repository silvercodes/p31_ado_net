using System;
using System.Collections.Generic;

namespace _08_mig_practice.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
}
