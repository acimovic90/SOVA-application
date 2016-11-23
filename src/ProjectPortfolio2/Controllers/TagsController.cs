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
            return Ok();
        }

        [HttpGet("{id}", Name = Config.TagRoute)]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpGet("{id}/posts", Name = Config.TagPostsRoute)]
        public IActionResult GetPosts(int id)
        {
            return Ok();
        }
    }
}