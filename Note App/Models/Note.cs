using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Note_App.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        // Foreign key to User
        [Required]
        [DisplayName("User ID")]
        public int UserId { get; set; }

        // Navigation property to represent the relationship
        public User? User { get; set; }
    }
}