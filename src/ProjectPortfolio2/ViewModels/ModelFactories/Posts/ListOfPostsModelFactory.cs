using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels
{
    public class ListOfPostsModelFactory
    {
        public static ListOfPostsViewModel Map(List<Post> posts, IUrlHelper url)
        {
            IPostService _uPostService = new PostService();

            var postsList = new List<PostListViewModel>(); //
            var postsViewModel = new ListOfPostsViewModel();
            
            foreach (var post in posts)
            {
                var tmp = new PostListViewModel
                {
                    Id = post.PostId,
                    Title = post.Title,
                    CreationDate = post.CreationDate,
                    Url = url.Link(Config.PostRoute, new { id = post.PostId }),
                };
                try
                {
                    var userIdList = new List<int>
                    {
                        post.UserId
                    };

                    var user = _uPostService.GetListOfUsers(userIdList);

                    tmp.User = new UserPostViewModel
                    {
                        Displayname = user[0].DisplayName,
                        CreationDate = user[0].CreationDate,
                        Url = url.Link(Config.UserRoute, new { id = user[0].Id})
                    };
                }
                catch (Exception)
                {
                }

                postsList.Add(tmp);
            }

            postsViewModel.Posts = postsList;

            return postsViewModel;
        }
    }
}
