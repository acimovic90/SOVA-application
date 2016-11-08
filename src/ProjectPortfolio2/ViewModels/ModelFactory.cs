using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace ProjectPortfolio2.ViewModels
{
    public class ModelFactory
    {
        public static UserViewModel Map(User user)
        {
            return new UserViewModel
            {
                Displayname = user.DisplayName,
                Age = user.Age.Value
            };
        }
    }
}
