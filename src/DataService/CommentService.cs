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
        public IList<Comment> GetCommentsById(int id)
        {
            using (var db = new SovaContext())
            {
                var comments = db.Comments
                    .Where(c => c.Id == id)
                    .ToList();

                return comments;
       
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
