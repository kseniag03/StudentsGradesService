using Microsoft.AspNetCore.Mvc;
using StudentsGradesService.Models;
using StudentsGradesService.Repositories;

namespace StudentsGradesService.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController: ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    
    private readonly IGradesRepository _gradesRepository;
    
    public StudentController(IStudentRepository studentRepository, IGradesRepository gradesRepository)
    {
        _studentRepository = studentRepository;
        _gradesRepository = gradesRepository;
    }
    
    [HttpGet("get-all-students")]
    public async Task<ActionResult<List<Student>>> GetAllStudents()
    {
        try
        {
            var list = await _studentRepository.FindAllStudents();
            if (list.Count == 0)
            {
                return NotFound("Students list is empty");
            }
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("add-new-student")]
    public async Task<ActionResult<Student>> AddStudent(Student student)
    {
        try
        {            
            if (_studentRepository.FindStudentById(student.Id).Result != null)
            {
                return BadRequest("no shadow cloning technique pls");
            }
            if (student.Age is < 0 or > 150)
            {
                return BadRequest("Strange subject detected............");
            }
            await _studentRepository.AddNewStudent(student);
            return Ok(student);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("get-all-student-grades")]
    public async Task<ActionResult<List<Grade>>> GetStudentGrades(int studentId)
    {
        try
        {
            if (_studentRepository.FindStudentById(studentId).Result == null)
            {
                return NotFound("schrodinger's student?..");
            }
            var list = await _studentRepository.FindStudentGrades(studentId);
            if (list.Count == 0)
            {
                return NotFound("Grades list is empty");
            }
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
        
    [HttpPost("add-student-new-grade")]
    public async Task<ActionResult<Grade>> AddGradeToStudent(Grade grade)
    {
        try
        {            
            if (_gradesRepository.FindGradeById(grade.Id).Result != null)
            {
                return BadRequest("no shadow cloning technique in grades too...");
            }
            if (grade.Score is < 0 or > 12)
            {
                return BadRequest("it's the spy... not from HSE...");
            }
            if (_studentRepository.FindStudentById(grade.StudentId).Result == null)
            {
                return NotFound("schrodinger's student?..");
            }
            await _gradesRepository.AddNewGradeToStudent(grade);
            return Ok(grade);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}