using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPortfolio2.ViewModels
{
    public class UserModelFactory
    {
        public static UserViewModel Map(User user, IUrlHelper url)
        {
            // add users posts as PostListViewModel objects
            var posts = new List<PostListViewModel>();

            foreach (var post in user.Posts)
            {
                var tmp = new PostListViewModel
                {
                    Id = post.PostId,
                    Title = post.Title,
                    Url = url.Link(Config.PostRoute, new { id = post.PostId }),
                };

                posts.Add(tmp);
            }

            // add users favourite posts as PostListViewModel objects
            var favouritePosts = new List<PostListViewModel>();

            foreach (var post in user.FavouritePosts)
            {
                var tmp = new PostListViewModel
                {
                    Id = post.PostId,
                    Title = post.Title,
                    Url = url.Link(Config.PostRoute, new { id = post.PostId }),
                };

                favouritePosts.Add(tmp);
            }

            return new UserViewModel
            {
                Url = url.Link(Config.UserRoute, new { id = user.Id }),
                Displayname = user.DisplayName,
                Age = user.Age.Value,
                CreationDate = user.CreationDate,
                Location = user.Location,
                Posts = posts,
                FavouritePosts = favouritePosts
            };
        }

        public static User Map(UserViewModel model)
        {
            return new User
            {
                DisplayName = model.Displayname,
                Age = model.Age
            };
        }
    }
}
