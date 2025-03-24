using _05_crud;

// === Add

//using Db db = new Db();

//db.Users.AddRange(
//    new User("Brus Willis", 34),    
//    new User("Chack Norris", 45),    
//    new User("Jekie Chan", 50)    
//);

//db.SaveChanges();


// === Select

//using Db db = new Db();

//// List<User> users = db.Users.ToList();
//// users.ForEach(u => Console.WriteLine(u));

//User user = db.Users.First(u => u.Id == 2);
//Console.WriteLine(user);


// == Update

//User? user = null;
//using (Db db = new Db())
//{
//    user = db.Users.First(u => u.Id == 2);
//}
////
////
////

//using (Db db = new Db())
//{
//    user.Name = "Vasia";

//    db.Update(user);        // Привязать к текущему контексту

//    db.SaveChanges();
//}


// == Delete

using Db db = new Db();

User user = db.Users.First(u => u.Id == 2);

db.Users.Remove(user);
db.SaveChanges();












