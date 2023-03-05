using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class PostCategory
    {
        [Column("CategoryID")]
        [Key] public int ID { get; set; }
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category description must be not empty!")]
        public string Description { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
