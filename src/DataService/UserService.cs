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
        public int GetNumberOfUsers()
        {
            using (var db = new SovaContext())
            {
                return db.Users
                    .Count();
            }
        }

        public List<User> GetUsers(int page, int pageSize)
        {
            using (var db = new SovaContext())
            {
                return db.Users
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

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

        public List<Post> GetUsersPosts(int id)
        {
            using (var db = new SovaContext())
            {
                var posts = db.Posts
                    .Where(p => p.UserId == id && p.PostTypeId == 1)
                    .ToList();

                return posts;
            }
        }

        public List<Post> GetUsersFavouritePosts(int id)
        {
            using (var db = new SovaContext())
            {
                var favouritePosts = db.Posts
                    .FromSql("call getFavouritePosts({0})", id)
                    .ToList();

                return favouritePosts;
            }
        }

        public void AddUser(User user)
        {
            using (var db = new SovaContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
        }
    }
}
