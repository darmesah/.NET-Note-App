using System.ComponentModel.DataAnnotations;

namespace Note_App.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }

        public ICollection<Note>? Notes { get; set; }
    }
}
