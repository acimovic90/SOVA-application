using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using DomainModels.Models;
using ProjectPortfolio2.Controllers;
using Xunit;
using Xunit.Sdk;

namespace ProjectPortfolio2
{
    public class UserTest
    {
        IUserService _userService = new UserService();


        [Fact]
        public void Should_return_single_user_object_and_check_for_correct_userid()
        {
            int userTestID = 13;

            var user2 = _userService.GetUserById(userTestID);

            //Check for valid user type
            Assert.IsType(new User().GetType(), user2);
            //check if it's the rigth user
            Assert.Equal(userTestID, user2.Id);
        }

        //public void
    }
}
