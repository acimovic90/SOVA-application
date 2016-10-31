using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.Models;

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
                return db.Posts.FirstOrDefault(p => p.Id == postId && p.PostTypeId == postTypeId);
            }
        }
    }
}
