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
    public class FavouritePostsModelFactory
    {
        public static FavouritePostsViewModel Map(List<Post> favouritePosts, IUrlHelper url)
        {
            var favouritePostsList = new List<PostListViewModel>();
            var favouritePostsViewModel = new FavouritePostsViewModel();

            foreach (var post in favouritePosts)
            {
                var tmp = new PostListViewModel
                {
                    Id = post.PostId,
                    Title = post.Title,
                    Url = url.Link(Config.PostRoute, new { id = post.PostId }),
                };

                favouritePostsList.Add(tmp);
            }

            favouritePostsViewModel.FavouritePosts = favouritePostsList;

            return favouritePostsViewModel;
        }
    }
}
