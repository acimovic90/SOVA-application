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

            var viewModel = ListOfTagsModelFactory.Map(tags, Url);

            var total = _tagService.GetNumberOfTags();

            var result = new
            {
                tags = viewModel.Tags,
                total = total,
                prev = GetPrevUrl(Url, Config.TagsRoute, page, pageSize),
                next = GetNextUrl(Url, Config.TagsRoute, page, pageSize, total)
            };

            return Ok(result);
        }

        [HttpGet("{id}", Name = Config.TagRoute)]
        public IActionResult Get(int id)
        {
            var tag = _tagService.GetTagById(id);
            if (tag == null) return NotFound();

            var viewModel = TagModelFactory.Map(tag, Url);
            return Ok(viewModel);
        }
    }
}