using Microsoft.EntityFrameworkCore;

namespace _09_attr_fluent_api;

internal class Db: DbContext
{
    public DbSet<User> Users { get; set; }

    public Db()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=p31_ef_attr_fapi_db;Trusted_Connection=True;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // mb.Ignore<Role>();

        // mb.Entity<User>().Ignore(u => u.Token);

        // mb.Entity<User>().ToTable("employees");

        //mb.Entity<User>()
        //    .Property(u => u.Email)
        //    .HasColumnName("user_email");

        //mb.Entity<User>()
        //    .Property(u => u.Age)
        //    .IsRequired();

        //mb.Entity<User>()
        //    .HasKey(u => u.Email);

        //mb.Entity<User>()
        //    .HasKey(u => new { u.Id, u.Email});
    }
}
