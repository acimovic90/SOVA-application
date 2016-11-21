using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataService;
using System.Net.Http;
using ProjectPortfolio2.ViewModels;
using ProjectPortfolio2.ViewModels.ModelFactories;

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

        // GET: api/values
        [HttpGet(Name = Config.PostsRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize, string searchFor = "")
        {
            var searchString = searchFor;
            var posts = _postService.GetPosts(page, pageSize, searchString);
            if (posts == null) return NotFound();
            var viewModel = ListOfPostsModelFactory.Map(posts.ToList(), Url);

            var total = _postService.GetNumberOfPosts();

            var result = new
            {
                posts = viewModel.Posts,
                total = total,
                prev = GetPrevUrl(Url, Config.PostsRoute, page, pageSize),
                next = GetNextUrl(Url, Config.PostsRoute, page, pageSize, total)
            };

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = Config.PostRoute)]
        public IActionResult GetPosts(int id)
        { 
            var post = _postService.GetPostById(id);
            if (post == null) return NotFound();
            var viewModel = PostModelFactory.Map(post, Url);

            return Ok(viewModel);
            //return Ok(post);
        }

        [HttpGet("{id}/comments", Name = Config.PostCommentRoute)]
        public IActionResult GetComments(int id)
        {
            var comment = _postService.GetCommentsByPostId(id);
            if (comment == null) return NotFound();
            var viewModel = ListOfCommentModelFactory.Map(comment, Url);

            return Ok(viewModel);
        }


        //[Route("wordCloud")]
        //[HttpGet(Name = Config.WordCloudRoute)]
        //public IActionResult WordCloud(int page = 0, int pageSize = Config.DefaultPageSize,string cloudType = "TF", string searchFor = "")
        //{
        //    var cloudTagList = _postService.GetWordCloudList(page, pageSize, cloudType, searchFor);

        //    if (cloudTagList == null) return NotFound();
        //    return Ok(cloudTagList);
        //}

       
    }
}
