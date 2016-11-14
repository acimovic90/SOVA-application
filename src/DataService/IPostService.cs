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
        int GetNumberOfPosts();
        Post GetPostById(int postId);
        IList<Post> GetAnswers(int postId);
        IList<Post> GetPosts(int page, int pageSize);
        IList<Tag> GetTags(int postId);
        IList<User> GetListOfUsers(List<int> userIds);
        IList<Comment> GetComments(int postId);

    }
}