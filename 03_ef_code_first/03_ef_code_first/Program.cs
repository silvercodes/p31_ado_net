
using _03_ef_code_first;

using Db db = new Db();

User a = new User() { Email = "vasia@mail.com", Password = "password", Age = 21};
Console.WriteLine(a);

db.Users.Add(a);

db.SaveChanges();

Console.WriteLine(a);