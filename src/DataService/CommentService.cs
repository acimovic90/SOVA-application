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
        public Comment GetCommentById(int id)
        {
            using (var db = new SovaContext())
            {
                var comment = db.Comments.FirstOrDefault(c => c.Id == id);
               

                var user = GetUserById(comment.UserId);
                comment.User = user;
                return comment;
            }
        }

        public List<Comment> GetAllComments(int page, int pageSize)
        {
            using (var db = new SovaContext())
            {
                var comments = db.Comments
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                return comments;
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
