using StudentsGradesService.Models;

namespace StudentsGradesService.Repositories;

public interface IGradesRepository
{
    public Task<Grade?> FindGradeById(int id);
    
    /// <summary>
    /// Add new grade to student and update grade table in db.
    /// </summary>
    /// <param name="grade"> New grade </param>
    public Task AddNewGradeToStudent(Grade grade);
}