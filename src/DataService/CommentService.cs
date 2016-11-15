using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class CommentService : ICommentService
    {
        public List<Comment> GetComments(int postId)
        {
            using (var db = new SovaContext())
            {
                var comments = db.Comments
                    .FromSql("call getComments({0})", postId);
                //return comment;
                //db.Users.FirstOrDefault(u => u.Id == comment.UserId);
                //var user = GetUserById(comment.UserId);
                //comment.User = user;
                var result = new List<Comment>();
                foreach (var comment in comments)
                {
                    result.Add(comment);
                }
                return result;
            }
        }

        public List<Comment> GetAllComments(int page, int pageSize)
        {
            using (var db = new SovaContext())
            {
                return db.Comments
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
        public int GetNumberOfComments()
        {
            using (var db = new SovaContext())
            {

                var commentsCount = (from c in db.Comments
                                 select c).Count();


                return commentsCount;
            }
        }
        public User GetUserById(int id)
        {
            using (var db = new SovaContext())
            {
                User user = db.Users
                    .FromSql("call getUserById({0})", id).FirstOrDefault();

                // find users question posts

                return user;
            }
        }

    }
}
