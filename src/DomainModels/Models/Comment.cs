using System;

namespace DomainModels.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public User User { get; set; }

    }
}
