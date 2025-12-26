using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public double Degree { get; set; }


        public int CrsId { get; set; }
        [ForeignKey("CrsId")]
        public Course Course { get; set; }


        public int TraineeId { get; set; }
        [ForeignKey("TraineeId")]
        public Trainee Trainee { get; set; }
    }
}
