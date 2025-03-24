namespace _03_ef_code_first;

internal class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int? Age { get; set; }

    public override string ToString()
    {
        return $"id: {Id}, email: {Email}, pass: {Password}, age: {Age}";
    }
}
