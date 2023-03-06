using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class AppUser
    {
        [Column("AuthorID")]
        [Key] public int ID { get; set; }
        [Required(ErrorMessage = "Field name must be not empty")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address must be not empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email must be not empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password must be not empty")]
        public string Password { get; set; }

        [ForeignKey("AuthorID")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
