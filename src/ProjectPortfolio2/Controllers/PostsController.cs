using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataService;
using System.Net.Http;
using ProjectPortfolio2.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectPortfolio2.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
    
        // GET: api/posts
        [HttpGet(Name = Config.UsersRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            //var users = _postService.GetPosts(page, pageSize);
            //if (users == null) return NotFound();
            //var viewModel = UsersModelFactory.Map(users, Url);

            var total = _postService.GetNumberOfPosts();

            //var result = new
            //{
            //    users = users,
            //    total = total,
            //    prev = GetPrevUrl(Url, Config.UsersRoute, page, pageSize),
            //    next = GetNextUrl(Url, Config.UsersRoute, page, pageSize, total)
            //};

            return Ok(total);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = Config.PostRoute)]
        public IActionResult GetPosts(int id)
        { 
            var post = _postService.GetPostById(id);
            if (post == null) return NotFound();
            var viewModel = PostModelFactory.Map(post);

            return Ok(viewModel);
            //return Ok(post);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
