using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataService
{
    public interface ICommentService
    {
        //IList<Comment> GetUser(List<int> userid);
        int GetNumberOfComments();
        List<Comment> GetComments(int postid);
        List<Comment> GetAllComments(int page, int pageSize);
    }
}
