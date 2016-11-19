using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
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
            ICommentService _uCommentService = new CommentService();
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
                var user = _uCommentService.GetUserById(tmp.UserId);
                tmp.CommentUser = new CommentUserViewModel()
                {
                    Displayname = user.DisplayName,
                    CreationDate = user.CreationDate,
                    Url = url.Link(Config.UserRoute, new { id = user.Id })
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
    


