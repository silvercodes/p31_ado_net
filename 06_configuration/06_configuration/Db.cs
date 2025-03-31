using Microsoft.EntityFrameworkCore;

namespace _06_configuration;

internal class Db: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }



    #region Simple

    //private string? ConnString { get; set; }

    //public Db(string? connstring)
    //{
    //    ConnString = connstring;

    //    Database.EnsureDeleted();
    //    Database.EnsureCreated();
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (ConnString is null)
    //        throw new ArgumentException("Invalid connection string");

    //    optionsBuilder.UseSqlServer(ConnString);
    //}

    #endregion


    #region Options to DbContext

    public Db(DbContextOptions<Db> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
        
    #endregion




}
