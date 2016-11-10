using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using DomainModels.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace DataService
{
    public class PostService : IPostService
    {
        public Post GetPostById(int postId)
        {
            using (var db = new SovaContext())
            {
                Post post = db.Posts
                    .FromSql("call getSinglePost({0})", postId).FirstOrDefault();

                db.Users.FirstOrDefault(u => u.Id == post.UserId);
                         
                db.Comments.Where(c => c.PostId == postId).ToList().FirstOrDefault();
                

                 
                //Get comments
                //post.Comments = GetComments(postId);


                //Get answers
                var answers = GetAnswers(postId);

                foreach (var answer in answers)
                {
                    if (answer.PostId == post.AcceptedAnswerId)
                    {                  
                        post.AcceptedAnswer = answer;
                    }
                    else
                    {
                        post.Answers.Add(answer);
                    }
                }

                return post;
            }

        }

        private List<Comment> GetComments(int postId)
        {
            using (var db = new SovaContext())
            {
                var result = db.Comments.FromSql("call getComments({0})", postId);

                return result.ToList();

            }
        }

        public IList<Post> GetAnswers(int postId)
        {
            using (var db = new SovaContext())
            {
                var result = db.Posts.FromSql("call getAnswers({0})", postId);

                foreach (var post in result)
                {
                    
                    post.Comments = GetComments(Convert.ToInt32(post.PostId));

                }


                return result.ToList();

            }

        }
        
    }
}