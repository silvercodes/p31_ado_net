namespace _05_crud;

internal class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name; 
        Age = age;
    }

    public override string ToString()
    {
        return $"id: {Id}, name: {Name}, age: {Age}";
    }
}
