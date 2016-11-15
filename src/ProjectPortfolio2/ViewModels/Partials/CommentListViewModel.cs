using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels.Partials
{
    public class CommentListViewModel
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public DateTime? CreateDate { get; set; }
        //public UserPostViewModel User { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
