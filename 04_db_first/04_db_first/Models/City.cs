using System;
using System.Collections.Generic;

namespace _04_db_first.Models;

public partial class City
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
