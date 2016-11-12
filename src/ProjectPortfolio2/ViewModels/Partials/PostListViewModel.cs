using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels.Partials
{
    public class PostListViewModel
    {
        public int ?Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
        public UserPostViewModel User { get; set; }
        public List<CommentViewModel> Comment { get; set; }
    }
}
