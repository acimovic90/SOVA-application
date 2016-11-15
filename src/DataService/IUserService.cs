using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataService
{
    public interface IUserService
    {
        int GetNumberOfUsers();
        List<User> GetUsers(int page, int pageSize);
        User GetUserById(int id);
        List<Post> GetUsersPosts(int id);
        List<Post> GetUsersFavouritePosts(int id);
        void AddUser(User user);
        bool UpdateUser(User user);
    }
}
