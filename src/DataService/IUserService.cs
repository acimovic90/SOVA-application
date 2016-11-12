using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataService
{
    public interface IUserService
    {
        User GetUserById(int id);
        List<Post> GetUsersFavouritePosts(int id);
    }
}
