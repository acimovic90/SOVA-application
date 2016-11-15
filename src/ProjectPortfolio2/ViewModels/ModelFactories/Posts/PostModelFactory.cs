using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using ProjectPortfolio2.ViewModels.Partials;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels
{
    public class PostModelFactory
    {
        public static PostViewModel Map(Post post, IUrlHelper url)
        {

            return new PostViewModel
            {
                PostId = post.PostId,
                CreationDate = post.CreationDate,
                Score = post.Score,
                Body = post.Body,
                ClosedDate = post.ClosedDate,
                Title = post.Title,
                Comments = GetListOfCommentsView(post.Comments, url),
                //User = GetUserViewModel(post.User),
                User = new UserPostViewModel
                {
                    Displayname = post.User.DisplayName,
                    CreationDate = post.User.CreationDate,
                    Url = url.Link(Config.UserRoute, new { id = post.User.Id })
                },
                AcceptedAnswer = getAcceptedAnswerView(post, url),
                Answers = getListOfAnswerView(post, url),
                Tags = post.TagsList,
                RelatedPosts = post.RelatedPostsLists
            };
        }

        public static List<PostListViewModel> getListOfAnswerView(Post post, IUrlHelper url)
        {
            var answers = new List<PostListViewModel>();

            foreach (var item in post.Answers)
            {
                var tmp = new PostListViewModel
                {
                    Id = item.PostId,
                    Title = item.Title,
                    CreationDate = item.CreationDate,
                    Body = item.Body,
                    Score = item.Score,
                    Comment = GetListOfCommentsView(item.Comments, url)
                };
                try
                {
                    tmp.User = new UserPostViewModel
                    {
                        Displayname = item.User.DisplayName,
                        CreationDate = item.User.CreationDate,
                        Url = url.Link(Config.UserRoute, new { id = post.User.Id })
                    };
                }
                catch (Exception)
                {
                    //catch exception and skip if user doesn't exist
                }

                answers.Add(tmp);
            }
            return answers;
        }

        public static List<CommentViewModel> GetListOfCommentsView(List<Comment> commentList, IUrlHelper url)
        {
            var comments = new List<CommentViewModel>();
            foreach (var comment in commentList)
            {
                var tmp = new CommentViewModel
                {
                    Id = comment.Id,
                    CreateDate = comment.CreateDate,
                    Score = comment.Score,
                    Text = comment.Text,
                    Url = url.Link(Config.CommentRoute, new { id = comment.Id })
                };
                try
                {
                    tmp.User = new UserPostViewModel
                    {                     
                        Displayname = comment.User.DisplayName,
                        CreationDate = comment.User.CreationDate,
                        Url = url.Link(Config.UserRoute, new { id = comment.User.Id })
                    };
                }
                catch (Exception)
                {
                    //catch exception and skip if user doesn't exist
                }
                comments.Add(tmp);
            }
            return comments;
        }

        public static AcceptedPostViewModel getAcceptedAnswerView(Post post, IUrlHelper url)
        {
            // create accepted answer using viewModel
            var acceptedAnswer = new AcceptedPostViewModel
            {
                CreationDate = post.AcceptedAnswer.CreationDate,
                Body = post.AcceptedAnswer.Body,
                Score = post.AcceptedAnswer.Score,
                Title = post.AcceptedAnswer.Title,
                Comments = GetListOfCommentsView(post.AcceptedAnswer.Comments, url),
            };
            try
            {
                acceptedAnswer.User = new UserPostViewModel
                {
                    CreationDate = post.AcceptedAnswer.User.CreationDate,
                    Displayname = post.AcceptedAnswer.User.DisplayName,
                    Url = url.Link(Config.UserRoute, new { id = post.User.Id })
                };
            }
            catch (Exception)
            {
                //catch exception and skip if user doesn't exist
            }

            return acceptedAnswer;
        }
    }
}
