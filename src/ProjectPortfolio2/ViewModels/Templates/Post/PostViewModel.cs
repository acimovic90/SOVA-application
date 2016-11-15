using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels
{
    public class PostViewModel
    {
        public int? PostId { get; set; }
        //public int PostTypeId { get; set; }
        //public int? AcceptedAnswerId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Title { get; set; }

        //public int UserId { get; set; }
        public UserPostViewModel User { get; set; }

        public List<PostListViewModel> Answers { get; set; }

        public AcceptedPostViewModel AcceptedAnswer = null;

        public List<CommentViewModel> Comments { get; set; }

        public List<Tag> Tags { get; set; }

        public List<RelatedPost> RelatedPosts { get; set; }
    }

}
