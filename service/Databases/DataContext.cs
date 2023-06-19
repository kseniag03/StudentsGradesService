
using StudentsGradesService.Models;

namespace StudentsGradesService.Databases;

/// <summary>
/// Representation of PostgresSQL database.
/// </summary>
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost; Database=sgdb; Username=postgres; Password=_4a^h%7AF$v");
    }

    public DbSet<Student> Students => Set<Student>();
    
    public DbSet<Grade> Grades => Set<Grade>();
}