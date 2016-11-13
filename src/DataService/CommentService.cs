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
                return comment;

            }
        }
    }
}
