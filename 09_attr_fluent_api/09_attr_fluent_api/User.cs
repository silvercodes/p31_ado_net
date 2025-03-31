using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _09_attr_fluent_api;

//[Table("employees")]
internal class User
{
    public int Id { get; set; }
    // [Column("user_email")]
    // [Key]
    public string Email { get; set; }
    // [Required]
    public int? Age { get; set; }
    public Role? Role { get; set; }
    // [NotMapped]
    public string Token { get; set; } = string.Empty;

}
