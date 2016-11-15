using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2.ViewModels.Templates.User;

namespace ProjectPortfolio2.ViewModels
{
    public class ListOfUsersModelFactory
    {
        public static ListOfUsersViewModel Map(List<User> users, IUrlHelper url)
        {
            var usersList = new List<UserListViewModel>();

            foreach (var user in users)
            {
                var tmp = new UserListViewModel
                {
                    Id = user.Id,
                    Displayname = user.DisplayName,
                    Location = user.Location,
                    Age = user.Age,
                    Url = url.Link(Config.UserRoute, new { id = user.Id })
                };

                usersList.Add(tmp);
            }

            return new ListOfUsersViewModel
            {
                Users = usersList
            };
        }
    }
}
