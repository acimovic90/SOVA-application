using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels.Partials
{
    public class CommentListViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UserId { get; set; }
        public CommentUserViewModel CommentUser { get; set; }
        public UserPostViewModel User { get; set; }
       
    }
}
