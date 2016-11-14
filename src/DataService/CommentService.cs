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
        public Comment GetComments(int postId)
        {
            using (var db = new SovaContext())
            {
                Comment comment = db.Comments
                    .FromSql("call getComments({0})", postId).FirstOrDefault();
                //return comment;
                db.Users.FirstOrDefault(u => u.Id == comment.UserId);
                var user = GetUserById(comment.UserId);
                comment.User = user;
                return comment;
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
