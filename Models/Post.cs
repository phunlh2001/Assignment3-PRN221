using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        [Column("[content]")]
        public string Content { get; set; }
        public Status PublishStatus { get; set; } = Status.Published;


        public virtual PostCategory PostCategory { get; set; }
        public virtual AppUser Author { get; set; }
    }

    public enum Status
    {
        Published,
        Unpublished,
    }
}
