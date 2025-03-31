﻿using System;
using System.Collections.Generic;

namespace _08_mig_practice.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();
}
