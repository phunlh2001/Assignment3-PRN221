using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class Post
    {
        [Column("PostID")]
        [Key] public int ID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }

        [Column("created_date")]
        public string CreatedDate
        {
            get
            {
                return DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        [Column("updated_date")]
        public string UpdatedDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

        [Required(ErrorMessage = "Title must be not empty!")]
        public string Title { get; set; }
        public string Content { get; set; }
        public Status? PublishStatus { get; set; } = Status.Published;

        public virtual PostCategory PostCategory { get; set; }
        public virtual AppUser Author { get; set; }
    }

    public enum Status
    {
        Published,
        Unpublished,
    }
}
