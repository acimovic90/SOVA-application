using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    public class Post //I fokus lige nu
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("posttypeid")]
        public int PostTypeId { get; set; }
        [Column("creationdate")]
        public DateTime CreationDate { get; set; }
        [Column("score")]
        public int Score { get; set; }
        [Column("body")]
        public string Body { get; set; }
        [Column("closeddate")]
        public DateTime ClosedDate { get; set; }
        [Column("title")]
        public string Title { get; set; }

        public User User { get; set; }

        
    }
}
