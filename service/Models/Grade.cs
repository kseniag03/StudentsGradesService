using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsGradesService.Models;

[Table("grade")]
public class Grade
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("student_id")]
    public int StudentId { get; set; }
    
    [Column("subject")]
    public string Subject { get; private set; }
    
    [Column("score")]
    public int Score { get; set; }
    
    public Grade(int studentId, string subject, int score)
    {
        StudentId = studentId;
        Subject = subject;
        Score = score;
    }
}