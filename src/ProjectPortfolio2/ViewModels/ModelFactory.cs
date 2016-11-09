using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;

namespace ProjectPortfolio2.ViewModels
{
    public class ModelFactory
    {
        public static UserViewModel Map(User user)
        {
            var posts = new List<PostListViewModel>();

            foreach (var post in user.Posts)
            {
                var tmp = new PostListViewModel
                {
                    Id = post.Id,
                    Title = post.Title
                };

                posts.Add(tmp);
            }


            return new UserViewModel
            {

                Displayname = user.DisplayName,
                Age = user.Age.Value,
                CreationDate = user.CreationDate,
                Location = user.Location,
                Posts = posts
            };
        }
    }
}
