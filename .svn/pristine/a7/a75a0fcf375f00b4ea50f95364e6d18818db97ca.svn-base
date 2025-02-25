
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CourseWeb.Models
{
    public class Candidate
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual UserModel UserModel { get; set; }

        [MaxLength(19)]
        public string? SelectedCourse { get; set; } = string.Empty;
        public DateTime ApplyAt { get; set; }

        public Candidate() => ApplyAt = DateTime.Now;






    }
}
