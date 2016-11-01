using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DomainModels.Models;
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

        public Post GetPostById(int postId, int postTypeId)
        {
            using (var db = new SovaContext())
            {
                var post = db.Posts.FromSql("getSinglePost @p0, @p1",
                    parameters: new[] { postId, postTypeId }).FirstOrDefault();

                return db.Posts.FromSql("getSinglePost @p0, @p1", postId, postTypeId).FirstOrDefault();


                //return db.Posts.FromSql("getSinglePost @p0, @p1").FirstOrDefault(p => p.Id == postId && p.PostTypeId == postTypeId);
            }

        }
    }
}
