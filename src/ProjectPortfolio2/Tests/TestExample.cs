using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using DomainModels.Models;
using ProjectPortfolio2.Controllers;
using Xunit;

namespace ProjectPortfolio2
{
    public class TestExample
    {
        [Fact]
        public void Type_WhatToDo_ExpectedResult()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Should_return_single_user()
        {
            IUserService _userService = new UserService();
            User user1 = new User();
            var user2 = _userService.GetUserById(13);

            Assert.IsType(user1.GetType(), user2);
        }

        
    }
}
