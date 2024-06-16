using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASPTutorial.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "กรุณากรอกชื่อนักเรียน")]
        [DisplayName("ชื่อนักเรียน")]
        public string Name { get; set; }

        [DisplayName("คะแนนนักเรียน")]
        [Range(0, 100, ErrorMessage = "กรุณาป้อนคะแนนในช่วง 0 - 100")]
        public int Score { get; set; }
    }
}