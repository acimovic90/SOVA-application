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
    [Route("api/tags")]
    public class TagsController : BaseController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet(Name = Config.TagsRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var tags = _tagService.GetTags(page, pageSize);
            if (tags == null) return NotFound();

            return Ok(tags);

            //var viewModel = ListOfUsersModelFactory.Map(users, Url);

            //var total = _userService.GetNumberOfUsers();

            //var result = new
            //{
            //    users = viewModel.Users,
            //    total = total,
            //    prev = GetPrevUrl(Url, Config.UsersRoute, page, pageSize),
            //    next = GetNextUrl(Url, Config.UsersRoute, page, pageSize, total)
            //};

            //return Ok(result);
        }

        [HttpGet("{id}", Name = Config.TagRoute)]
        public IActionResult Get(int id)
        {
            var tag = _tagService.GetTagById(id);
            if (tag == null) return NotFound();

            var viewModel = TagModelFactory.Map(tag, Url);
            return Ok(viewModel);
        }

        [HttpGet("{id}/posts", Name = Config.TagPostsRoute)]
        public IActionResult GetPosts(int id)
        {
            return Ok("3");
        }
    }
}