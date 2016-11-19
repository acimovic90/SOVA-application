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
    public class ListOfCommentModelFactory
    {
        public static ListOfCommentsViewModel Map(List<Comment> comments, IUrlHelper url)
        {
            var commentsList = new List<CommentListViewModel>(); //Must be the same in ListOfCommentsViewModel                                       
            foreach (var comment in comments)
            {

                var tmp = new CommentListViewModel
                {
                    Id = comment.Id,
                    Url = url.Link(Config.CommentRoute, new { id = comment.Id }),
                    Score = comment.Score,
                    Text = comment.Text,
                    CreateDate = comment.CreateDate,
                    UserId = comment.UserId
                    
                    
                };

                commentsList.Add(tmp);
            }

            return new ListOfCommentsViewModel()
            {
                Comments = commentsList
            };
        }
    }
}
    


