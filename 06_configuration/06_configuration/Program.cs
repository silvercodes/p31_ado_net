
using _06_configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine();

//string connString = @"Server=.\SQLEXPRESS;Database=p31_ef_config_db;Trusted_Connection=True;Encrypt=False;";

//using Db db = new Db(connString);

//db.Users.Add(new User() { Email = "vasia@mail.com", Password = "qwerty" });
//db.SaveChanges();






//string connString = @"Server=.\SQLEXPRESS;Database=p31_ef_config_db;Trusted_Connection=True;Encrypt=False;";

//DbContextOptionsBuilder<Db> builder = new DbContextOptionsBuilder<Db>();
//builder.UseSqlServer(connString);
////
////
//DbContextOptions<Db> options = builder.Options;         // <--- Построение опция

//using Db db = new Db(options);

//db.Users.Add(new User() { Email = "vasia@mail.com", Password = "qwerty" });
//db.SaveChanges();







ConfigurationBuilder cBuilder = new ConfigurationBuilder();
cBuilder.SetBasePath(Directory.GetCurrentDirectory());

cBuilder.AddJsonFile("mainConfig.json");
//
//
//
IConfigurationRoot config = cBuilder.Build();

string? connString = config.GetConnectionString("express");

Console.WriteLine(connString);


DbContextOptionsBuilder<Db> builder = new DbContextOptionsBuilder<Db>();
builder.UseSqlServer(connString);
//
//
DbContextOptions<Db> options = builder.Options;         // <--- Построение опция

using Db db = new Db(options);

db.Users.Add(new User() { Email = "vasia@mail.com", Password = "qwerty" });
db.SaveChanges();


