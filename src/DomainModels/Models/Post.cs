using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    [Table("posts")]
    public class Post
    {
        [Column("id")]
        public int ?Id { get; set; }
        [Column("posttypeid")]
        public int PostTypeId { get; set; }
        [Column("acceptedanswerid")]
        public int ?AcceptedAnswerId { get; set; }
        [Column("creationdate")]
        public DateTime CreationDate { get; set; }
        [Column("score")]
        public int Score { get; set; }
        [Column("body")]
        public string Body { get; set; }
        [Column("closeddate")]
        public DateTime ?ClosedDate { get; set; }
        [Column("title")]
        public string Title { get; set; }

        [Column ("userid")]
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Post> Answers =new List<Post>();
        public List<Post> AcceptedAnswer = new List<Post>();
    }
}
