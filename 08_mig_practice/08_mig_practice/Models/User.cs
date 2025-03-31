using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08_mig_practice.Models;

public partial class User
{
    public int Id { get; set; }

    [Column("user_email")]
    public string Email { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual TeachersProfile? TeachersProfile { get; set; }
}
