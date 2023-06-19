using StudentsGradesService.Databases;
using StudentsGradesService.Models;
using StudentsGradesService.Repositories;

namespace StudentsGradesService.Services;

/// <summary>
/// Class for students management, implements IStudentRepository interface.
/// </summary>
public class StudentService: IStudentRepository
{
    /// <summary>
    /// Database with tables (used student and grade).
    /// </summary>
    private readonly DataContext _database;

    public StudentService(DataContext database)
    { 
        _database = database;
    }

    public async Task<List<Student>> FindAllStudents()
    {
        var list = await _database.Students.ToListAsync();
        return list;
    }

    public async Task<Student?> FindStudentById(int id)
    {
        var st = await _database.Students.FindAsync(id);
        return st;
    }
    
    public async Task AddNewStudent(Student student)
    {
        await _database.Students.AddAsync(student);
        await _database.SaveChangesAsync();
    }

    public async Task<List<Grade>> FindStudentGrades(int id)
    {
        var list = await _database.Grades.Where(x => x.StudentId == id).ToListAsync();
        return list;
    }
}
