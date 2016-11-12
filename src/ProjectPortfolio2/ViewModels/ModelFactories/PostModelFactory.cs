using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels
{
    public class PostModelFactory
    {
        public static PostViewModel Map(Post post)
        {



            return new PostViewModel
            {
                PostId = post.PostId,
                CreationDate = post.CreationDate,
                Score = post.Score,
                Body = post.Body,
                ClosedDate = post.ClosedDate,
                Title = post.Title,
                Comments = GetListOfCommentsView(post.Comments),
                User = new UserPostViewModel
                {
                    Displayname = post.User.DisplayName,
                    CreationDate = post.User.CreationDate
                },
                AcceptedAnswer = getAcceptedAnswerView(post),
                Answers = getListOfAnswerView(post)
            };
        }

        public static List<PostListViewModel> getListOfAnswerView(Post post)
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
                    Comment = GetListOfCommentsView(item.Comments)
                };
                try
                {
                    tmp.User = new UserPostViewModel
                    {
                        Displayname = item.User.DisplayName,
                        CreationDate = item.User.CreationDate,
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

        public static List<CommentViewModel> GetListOfCommentsView(List<Comment> commentList)
        {
            var comments = new List<CommentViewModel>();
            foreach (var comment in commentList)
            {
                var tmp = new CommentViewModel
                {
                    CreateDate = comment.CreateDate,
                    Score = comment.Score,
                    Text = comment.Text,
                };
                try
                {
                    tmp.User = new UserPostViewModel
                    {
                        Displayname = comment.User.DisplayName,
                        CreationDate = comment.User.CreationDate
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

        public static AcceptedPostViewModel getAcceptedAnswerView(Post post)
        {
            // create accepted answer using viewModel
            var acceptedAnswer = new AcceptedPostViewModel
            {
                CreationDate = post.AcceptedAnswer.CreationDate,
                Body = post.AcceptedAnswer.Body,
                Score = post.AcceptedAnswer.Score,
                Title = post.AcceptedAnswer.Title,
                Comments = GetListOfCommentsView(post.AcceptedAnswer.Comments),
            };
            try
            {
                acceptedAnswer.User = new UserPostViewModel
                {
                    CreationDate = post.AcceptedAnswer.User.CreationDate,
                    Displayname = post.AcceptedAnswer.User.DisplayName
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
