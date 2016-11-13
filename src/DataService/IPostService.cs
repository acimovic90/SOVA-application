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
        Post GetPostById(int postId);
        IList<Post> GetAnswers(int postId);
        //IList<Comment> GetComments(int postId);
        IList<Tag> GetTags(int postId);

    }
}