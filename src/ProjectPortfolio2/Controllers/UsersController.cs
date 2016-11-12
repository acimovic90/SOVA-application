using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataService;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels;

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
        
        [HttpGet("{id}", Name = Config.UserRoute)]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            var viewModel = UserModelFactory.Map(user, Url);

            return Ok(viewModel);
        }

        [HttpGet("{id}/favouriteposts", Name = Config.UserFavouritePostsRoute)]
        public IActionResult GetFavouritePosts(int id)
        {
            var favouritePosts = _userService.GetUsersFavouritePosts(id);
            if (favouritePosts == null) return NotFound();
            var viewModel = FavouritePostsModelFactory.Map(favouritePosts, Url);

            return Ok(viewModel);
        }
    }
}
