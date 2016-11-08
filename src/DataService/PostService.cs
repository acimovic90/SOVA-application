using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DomainModels.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace DataService
{
    public class PostService : IPostService
    {
        public IList<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetUsersPosts(int userId)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int postId)
        {
            using (var db = new SovaContext())
            {
                Post post = db.Posts
                    .FromSql("call getSinglePost({0})", postId).FirstOrDefault();

                db.Users.FirstOrDefault(u => u.Id == post.UserId);

                var answers = GetAnswers(postId);

                foreach (var answer in answers)
                {
                    if (answer.Id == post.AcceptedAnswerId)
                    {
                        post.AcceptedAnswer.Add(answer);
                    }
                    else
                    {
                        post.Answers.Add(answer);
                    }
                }

                return post;
            }

        }

        public IList<Post> GetAnswers(int postId)
        {
            using (var db = new SovaContext())
            {
                var result = db.Posts.FromSql("call getAnswers({0})", postId);

                return result.ToList();

            }

        }
    }
}