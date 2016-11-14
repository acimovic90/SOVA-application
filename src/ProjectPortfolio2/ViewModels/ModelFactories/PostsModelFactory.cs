using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels
{
    public class PostsModelFactory
    {
        public static PostsViewModel Map(List<Post> posts, IUrlHelper url)
        {
            var postsList = new List<PostListViewModel>(); //
            var postsViewModel = new PostsViewModel();

            foreach (var post in posts)
            {
                var tmp = new PostListViewModel
                {
                    Id = post.PostId,
                    Title = post.Title,
                    Url = url.Link(Config.PostRoute, new { id = post.PostId }),
                };

                postsList.Add(tmp);
            }

            postsViewModel.Posts = postsList;

            return postsViewModel;
        }
    }
}
