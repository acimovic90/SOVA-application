using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2.ViewModels.Partials;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels.ModelFactories
{
    public class CommentModelFactory
    {
        public static List<CommentViewModel> Map(IList<Comment> comments, IUrlHelper url) //Ændret list til ilist skulle der opstå fejl nogle steder
        {
            var commentsList = new List<CommentViewModel>(); //
                                                             //var commentsViewModel = new CommentViewModel();

            foreach (var comment in comments)
            {

                var commentsViewModel = new CommentViewModel
                {
                    Id = comment.Id,
                    Url = url.Link(Config.CommentRoute, new { id = comment.Id }),
                    Score = comment.Score,
                    Text = comment.Text,
                    CreateDate = comment.CreateDate
                };
                //Text = comment.Text,
                //CreateDate = comment.CreateDate
                commentsList.Add(commentsViewModel);
            };
            //        Text = comment.Text,
            //        CreateDate = comment.CreateDate,
            //        Url = url.Link(Config.PostRoute, new { id = comment.Id })
            return commentsList;
        }
    }
}
    


