using entity_library;

namespace dao_library;

public static class MockDatabase
{
    public static List<Student> Students { get; set; } = new()
    {
        new Student { Id = 1, Name = "Lucía Gómez", Age = 20, Dni = "40123456", File = "1001" },
        new Student { Id = 2, Name = "Martín Pérez", Age = 22, Dni = "38987654", File = "1002" },
        new Student { Id = 3, Name = "Sofía Ramírez", Age = 19, Dni = "41555222", File = "1003" }
    };

    public static List<Course> Courses { get; set; } = new()
    {
        new Course { Id = 1, Name = "Programación III" },
        new Course { Id = 2, Name = "Bases de Datos" }
    };

    public static List<Activity> Activities { get; set; } = new()
    {
        new Activity { Id = 1, Title = "Primer parcial", Description = "Parcial sobre POO", Type = TypeActivity.Exam, Date = new DateTime(2026, 11, 10) },
        new Activity { Id = 2, Title = "TP API", Description = "Trabajo práctico de arquitectura en capas", Type = TypeActivity.Practical, Date = new DateTime(2026, 11, 20) },
        new Activity { Id = 3, Title = "Proyecto final", Description = "Proyecto integrador de la materia", Type = TypeActivity.Project, Date = new DateTime(2026, 12, 5) }
    };

    public static List<Team> Teams { get; set; } = new()
    {
        new Team { Id = 1, Name = "Los Halcones", Category = "Sub-15" },
        new Team { Id = 2, Name = "Los Pumas", Category = "Sub-17" }
    };

    public static List<Player> Players { get; set; } = new()
    {
        new Player { Id = 1, Name = "Tomás Díaz", Age = 14, Dni = "50111222", Numero = 10 },
        new Player { Id = 2, Name = "Nicolás Rojas", Age = 15, Dni = "49333444", Numero = 7 },
        new Player { Id = 3, Name = "Julián Castro", Age = 16, Dni = "48555666", Numero = 1 }
    };

    public static List<Trainer> Trainers { get; set; } = new()
    {
        new Trainer { Id = 1, Name = "Carlos Medina", Age = 45, Dni = "22333444" },
        new Trainer { Id = 2, Name = "Laura Fernández", Age = 38, Dni = "28777888" }
    };
}
