using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPortfolio2.ViewModels.Templates
{
    public class AcceptedPostViewModel
    {
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public UserPostViewModel User { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
