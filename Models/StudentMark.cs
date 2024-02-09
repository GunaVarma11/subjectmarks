using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStudentDatabase.Models
{
    [Table("Student")]
    public class StudentMark
    {
        [Key]
        public int StudentId { get; set; }
        public string ?StudentName { get; set; }
        public string ? SubjectName { get; set; }
        public int Mark { get; set; }
    }
}
