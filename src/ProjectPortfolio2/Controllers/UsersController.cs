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
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = Config.UsersRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var users = _userService.GetUsers(page, pageSize);
            if (users == null) return NotFound();
            var viewModel = ListOfUsersModelFactory.Map(users, Url);

            var total = _userService.GetNumberOfUsers();

            var result = new
            {
                users = viewModel.Users,
                total = total,
                Url = Url.Link(Config.UsersRoute, new { page, pageSize }), //changed
                prev = GetPrevUrl(Url, Config.UsersRoute, page, pageSize),
                next = GetNextUrl(Url, Config.UsersRoute, page, pageSize, total)
            };

            return Ok(result);
        }

        [HttpGet("{id}", Name = Config.UserRoute)]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            var viewModel = UserModelFactory.Map(user, Url);

            return Ok(viewModel);
        }

        [HttpGet("{id}/posts", Name = Config.UserPostsRoute)]
        public IActionResult GetPosts(int id)
        {
            var posts = _userService.GetUsersPosts(id);
            if (posts == null) return NotFound();
            var viewModel = ListOfPostsModelFactory.Map(posts, Url);

            return Ok(viewModel);
        }

        [HttpGet("{id}/favouriteposts", Name = Config.UserFavouritePostsRoute)]
        public IActionResult GetFavouritePosts(int id)
        {
            var favouritePosts = _userService.GetUsersFavouritePosts(id);
            if (favouritePosts == null) return NotFound();
            var viewModel = ListOfPostsModelFactory.Map(favouritePosts, Url);

            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel model)
        {
            var user = UserModelFactory.Map(model);
            user.CreationDate = DateTime.Now;
            _userService.AddUser(user);
            return Ok(UserModelFactory.Map(user, Url));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserViewModel model)
        {
            var user = UserModelFactory.Map(model);
            user.Id = id;

            if (!_userService.UpdateUser(user))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("delete/{id}")] //Just added
        public IActionResult PutDelete(int id, [FromBody] UserViewModel model)
        {
            var user = UserModelFactory.Map(model);
            user.Id = id;

            if (!_userService.UpdateDeleteUser(user))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_userService.DeleteUser(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}