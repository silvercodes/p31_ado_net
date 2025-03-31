

User a = new User("v@mail.c");
Console.WriteLine(a.ValidateEmail());


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
class EmailLengthAttribute : Attribute
{
    public int Length { get; }
    public EmailLengthAttribute(int length)
    {
        Length = length;
    }
}



[EmailLength(10)]
class User
{
    // [EmailLength(10)]
    public string Email { get; set; }
    public User(string email)
    {
        Email = email;
    }

    public bool ValidateEmail()
    {
        Type type = typeof(User);

        object[] attributes = type.GetCustomAttributes(false);

        foreach (object o in attributes)
        {
            if (o is EmailLengthAttribute ela)
            {
                if (Email.Length < ela.Length)
                    return false;
            }
        }

        return true;
    }
}
