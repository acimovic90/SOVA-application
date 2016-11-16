using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    [Table("comments")]
    public class Comment
    {
        [Column("commentid")]
        public int Id { get; set; }
        [Column("postid")]
        public int PostId { get; set; }
        [Column("commentscore")]
        public int Score { get; set; }
        [Column("commenttext")]
        public string Text { get; set; }
        [Column("commentcreatedate")]
        public DateTime CreateDate { get; set; }
        [Column("userid")]
        public int UserId { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}
