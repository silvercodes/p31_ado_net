﻿using System;
using System.Collections.Generic;

namespace _08_mig_practice.Models;

public partial class ScheduleItem
{

    public int Id { get; set; }

    public byte Number { get; set; }

    public TimeOnly ItemStart { get; set; }

    public TimeOnly ItemEnd { get; set; }

    public byte? Status { get; set; }

    public virtual ICollection<Pair> Pairs { get; set; } = new List<Pair>();
}
