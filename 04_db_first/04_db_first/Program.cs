

using _04_db_first.Models;

using P31PracticeDbContext db = new P31PracticeDbContext();

db.Roles.AddRange(
    new Role() { Title = "admin" },
    new Role() { Title = "guest" }
);

db.SaveChanges();

