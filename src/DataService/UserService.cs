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

                var posts = db.Posts
                    .Where(p => p.UserId == user.Id);

                foreach (var post in posts)
                {
                    var tmp = new Post();
                    tmp.Id = post.Id;
                    tmp.Title = post.Title;
                    tmp.PostTypeId = post.PostTypeId;
                    tmp.CreationDate = post.CreationDate;
                    tmp.Score = post.Score;
                    tmp.Body = post.Body;
                    tmp.UserId = post.UserId;
                    tmp.ClosedDate = tmp.ClosedDate;
                    tmp.User = tmp.User;

                    user.Posts.Add(tmp);
                }

                user.Age = posts.Count();

                return user;


                //var user = db.Users.FirstOrDefault(u => u.Id == id);

                // find users question posts
                //var posts = db.Posts
                //    .Where(p => p.UserId == id && p.PostTypeId == 1)
                //    .ToList();

                //user.DisplayName = posts.GetType().Name;

                //var posts = db.Posts
                //    .Where(p => p.UserId == id && p.PostTypeId == 1)
                //    .Select(p => new Post { Id = p.Id, Title = p.Title, CreationDate = p.CreationDate })
                //    .ToList();

                //user.Posts = posts;

                //return user;
            }
        }
    }
}
