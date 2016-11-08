using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataService
{
    public class UserService : IUserService
    {
        public User GetUserById(int id)
        {
            using (var db = new SovaContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }
    }
}
