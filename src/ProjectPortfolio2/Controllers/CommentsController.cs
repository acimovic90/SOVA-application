using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2.ViewModels;
using ProjectPortfolio2.ViewModels.ModelFactories;
using ProjectPortfolio2.ViewModels.ModelFactories.Comments;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectPortfolio2.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: api/values
        [HttpGet(Name = Config.CommentsRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var comment = _commentService.GetAllComments(page, pageSize);
            if (comment == null) return NotFound();
            var viewModel = ListOfCommentModelFactory.Map(comment, Url);

            var total = _commentService.GetNumberOfComments();

            var result = new
            {
                comments = viewModel.Comments,
                total = total,
                prev = GetPrevUrl(Url, Config.CommentsRoute, page, pageSize),
                next = GetNextUrl(Url, Config.CommentsRoute, page, pageSize, total)
            };

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = Config.CommentRoute)]
        public IActionResult Get(int id)
        {
            var comment = _commentService.GetCommentById(id);
            if (comment == null) return NotFound();
            var viewModel = CommentModelFactory.Map(comment, Url);

            return Ok(viewModel);
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
