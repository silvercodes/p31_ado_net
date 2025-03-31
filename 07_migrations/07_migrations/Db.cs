using Microsoft.EntityFrameworkCore;

namespace _07_migrations;

internal class Db: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public Db()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=p31_ef_migrations_db;Trusted_Connection=True;Encrypt=False;");
    }
}
