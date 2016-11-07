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

        public IList<Post> GetUsersPosts(int userId, int postTypeId)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int postId, int postTypeId) //Mangler return
        {
            using (var db = new SovaContext())
            {

                //var post = db.Posts.FirstOrDefault(c => c.Id == postId && c.PostTypeId == postTypeId);

                var result = db.Set<Post>() 
                    .FromSql("call getSinglePost({0},{1})", postId, postTypeId);
                
               
                return result.FirstOrDefault();
            }

        }
    }
}
