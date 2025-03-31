using System;
using System.Collections.Generic;

namespace _08_mig_practice.Models;

public partial class Pair
{
    public int Id { get; set; }

    public DateOnly PairDate { get; set; }

    public int ScheduleItemId { get; set; }

    public int SubjectId { get; set; }

    public string? Theme { get; set; }

    public bool IsOnline { get; set; }

    public int? ClassroomId { get; set; }

    public int TeacherId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual ScheduleItem ScheduleItem { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual TeachersProfile Teacher { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
