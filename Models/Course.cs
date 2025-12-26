using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public const double MinDegree = 50;


        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }


        public List<CrsInstructor> CrsInstructor { get; set; }

        
        public List<CrsResult> CrsResults { get; set; }
    }
}
