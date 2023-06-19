using StudentsGradesService.Databases;
using StudentsGradesService.Models;
using StudentsGradesService.Repositories;

namespace StudentsGradesService.Services;

public class GradesService: IGradesRepository
{
    private readonly DataContext _database;

    public GradesService(DataContext database)
    { 
        _database = database;
    }
    
    public async Task<Grade?> FindGradeById(int id)
    {
        var g = await _database.Grades.FindAsync(id);
        return g;
    }

    public async Task AddNewGradeToStudent(Grade grade)
    {
        await _database.Grades.AddAsync(grade);
        await _database.SaveChangesAsync();
    }
}