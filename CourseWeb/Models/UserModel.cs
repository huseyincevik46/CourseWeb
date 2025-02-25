using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWeb.Models
{
    public class UserModel
    {
        [Key] // Primary Key olarak tanımlar
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "Email is required")]

        public string? Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(19)]
        public string? FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(19)]
        public string? LastName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Password { get; set; } = string.Empty;

        [MaxLength(19)]
        public string? Gender { get; set; } = string.Empty;
        public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    }
}
