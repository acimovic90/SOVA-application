using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DomainModels.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

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

        public Post GetPostById(int postId) //Mangler return
        {
            using (var db = new SovaContext())
            {

                //var test = db.Posts.FirstOrDefault(c => c.Id == postId);

                var result = db.Posts.FromSql("call getSinglePost({0})", postId);

                var userId = result.Select(x => x.UserId).FirstOrDefault();

                db.Users.FirstOrDefault(u => u.Id == userId);

                

                foreach (var post in result)
                {
                    //post.User = db.
                }


                return result.FirstOrDefault();
            }

        }
    }
}
