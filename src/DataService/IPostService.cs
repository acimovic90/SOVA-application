using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.Models;

namespace DataService
{
    public interface IPostService
    {
        IList<Comment> GetComments();
        IList<Post> GetUsersPosts(int userId);
        Post GetPostById(int postId);


    }
}
