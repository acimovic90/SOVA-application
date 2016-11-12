using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class UserService : IUserService
    {
        public User GetUserById(int id)
        {
            using (var db = new SovaContext())
            {
                User user = db.Users
                    .FromSql("call getUserById({0})", id).FirstOrDefault();

                // find users question posts
                var posts = db.Posts
                    .Where(p => p.UserId == id && p.PostTypeId == 1)
                    .ToList();

                user.Posts = posts;

                // find users favourite posts
                var favouritePosts = db.Posts
                    .FromSql("call getFavouritePosts({0})", id)
                    .ToList();

                user.FavouritePosts = favouritePosts;

                return user;
            }
        }
    }
}
