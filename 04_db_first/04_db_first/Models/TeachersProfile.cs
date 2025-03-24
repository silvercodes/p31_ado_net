using System;
using System.Collections.Generic;

namespace _04_db_first.Models;

public partial class TeachersProfile
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();
}
