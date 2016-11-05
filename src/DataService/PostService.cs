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

                var post = db.Posts.FirstOrDefault(c => c.Id == postId && c.PostTypeId == postTypeId);


                //var bla = db.Database.ExecuteSqlCommand("getSinglePost @p0, @p1", parameters: new[] { postId, postTypeId});
                
                return post;


            }

        }
    }
}
