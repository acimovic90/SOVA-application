using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataService
{
    public interface IPostService
    {
        int GetNumberOfPosts();
        Post GetPostById(int postId);
        IList<Post> GetAnswers(int postId);
        IList<Post> GetPosts(int page, int pageSize, string searchFor);
        IList<Tag> GetTags(int postId);
        IList<User> GetListOfUsers(List<int> userIds);
        IList<Comment> GetComments(int postId);
        List<Comment> GetCommentsByPostId(int postId);
        IList<RelatedPost> GetRelatedPosts(int postId);
        IList<Post> GetPostBySearch(int page, int pageSize, string searchFor);
        IList<CloudTag> GetWordCloudList(int page, int pageSize, string cloudType, string searchFor);
        int? answersCount(int postId);
    }
}