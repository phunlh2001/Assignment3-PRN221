using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class PostCategory
    {
        [Column("CategoryID")]
        [Key] public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
