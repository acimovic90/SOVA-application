using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataService
{
    interface IUserService
    {
        IList<User> GetUsers();
        User GetUserById(int id);
    }
}
