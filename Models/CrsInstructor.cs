using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class CrsInstructor
    {
        public int Id { get; set; }


        public int InstructorId { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; }

        public int CrsId { get; set; }
        [ForeignKey("CrsId")]
        public Course Course { get; set; }
    }
}
