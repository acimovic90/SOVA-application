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
            return new UserViewModel
            {
                Url = url.Link(Config.UserRoute, new { id = user.Id }),
                Displayname = user.DisplayName,
                Age = user.Age.Value,
                CreationDate = user.CreationDate,
                Location = user.Location,
                Posts = ListOfPostsModelFactory.Map(user.Posts, url).Posts,
                FavouritePosts = ListOfPostsModelFactory.Map(user.FavouritePosts, url).Posts
            };
        }

        public static User Map(UserViewModel model)
        {
            return new User
            {
                DisplayName = model.Displayname,
                Age = model.Age,
                Location = model.Location
            };
        }
    }
}
