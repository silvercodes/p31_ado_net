﻿
namespace _07_migrations;

internal class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int? Age { get; set; }
    public short Status { get; set; }
}
