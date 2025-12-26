using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        public string Address { get; set; }
        public byte Level { get; set; }
        
        
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }


        public List<CrsResult> CrsResults { get; set; }
    }
}
