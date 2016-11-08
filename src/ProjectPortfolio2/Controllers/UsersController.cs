using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataService;
using DomainModels.Models;

namespace ProjectPortfolio2.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /*
        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var test = new User();
            test.Id = 123;
            test.DisplayName = "Pop";
            return Ok(test);

            var data = _userService.GetUserById(id);

            if (data == null) return NotFound();
            return Ok(data);
        }
        */
    }
}
