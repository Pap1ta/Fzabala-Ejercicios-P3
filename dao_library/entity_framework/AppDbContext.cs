using entity_library;
using Microsoft.EntityFrameworkCore;

namespace dao_library.entity_framework;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { } // No tiene que ir nada dentro de las llaves

    // Un DbSet por cada entidad que se guarda en la base de datos (cada uno representa una tabla)
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Activity> Activities { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Trainer> Trainers { get; set; } = null!;
}
