using StudentsGradesService.Models;

namespace StudentsGradesService.Repositories;

/// <summary>
/// Interface for users management,
/// connects AuthController with user and session table in database.
/// </summary>
public interface IStudentRepository
{
    /// <summary>
    /// Searches for all students in database student table.
    /// </summary>
    /// <returns> List of students found </returns>
    public Task<List<Student>> FindAllStudents();
    
    /// <summary>
    /// Searches for student in database student table by its id.
    /// </summary>
    /// <param name="id"> Student's id </param>
    /// <returns> Found student, if it is present in db, otherwise <c>null</c> </returns>
    public Task<Student?> FindStudentById(int id);

    /// <summary>
    /// Adds student to database in student table,
    /// updates database.
    /// </summary>
    /// <param name="student"> New student </param>
    public Task AddNewStudent(Student student);
    
    /// <summary>
    /// Searches for student grades list in database grade table by student's id.
    /// </summary>
    /// <param name="id"> Student's id </param>
    /// <returns> List of grades found </returns>
    public Task<List<Grade>> FindStudentGrades(int id);
}