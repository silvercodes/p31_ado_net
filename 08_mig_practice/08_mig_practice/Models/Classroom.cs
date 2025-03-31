﻿using System;
using System.Collections.Generic;

namespace _08_mig_practice.Models;

public partial class Classroom
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string? Title { get; set; }

    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();
}
