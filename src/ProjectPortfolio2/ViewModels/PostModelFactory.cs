using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;

namespace ProjectPortfolio2.ViewModels
{
    public class PostModelFactory
    {
        public static PostViewModel Map(Post post)
        {
            var answers = new List<PostListViewModel>();

            foreach (var item in post.Answers)
            {
                var tmp = new PostListViewModel
                {
                    Id = item.PostId,
                    Title = item.Title
                };

                answers.Add(tmp);
            }


            return new PostViewModel
            {
                PostId = post.PostId,
                CreationDate = post.CreationDate,
                Score = post.Score,
                Body = post.Body,
                ClosedDate = post.ClosedDate,
                Title = post.Title,
                AcceptedAnswer = post.AcceptedAnswer,
                Answers = answers
            };
        }
    }
}
