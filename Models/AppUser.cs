using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class AppUser
    {
        [Column("AuthorID")]
        [Key] public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("AuthorID")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
