using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradesService.Models;

[Table("student")]
public class Student
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; private set; } = string.Empty;
    
    [Column("age")]
    public int Age { get; set; }
    
    [Column("specialization")]
    public string Specialization { get; private set; } = string.Empty;

    public Student(string name, int age, string specialization)
    {
        Name = name;
        Age = age;
        Specialization = specialization;
    }
}