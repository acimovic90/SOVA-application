using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.Models;

namespace DataService
{
    public interface IDataService
    {
        IList<Comment> GetComments();
        IList<Post> GetUsersPosts(int userId, int postTypeId);
        Post GetSinglePost(int postId, int postTypeId);


    }
}
