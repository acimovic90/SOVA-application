using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using Microsoft.AspNetCore.Mvc.Routing;
using ProjectPortfolio2.Controllers;
using Xunit;

namespace ProjectPortfolio2.Tests
{
    public class PostTest
    {
        private static readonly IPostService PostService = new PostService();
        private static readonly PostsController PostsController = new PostsController(PostService);

        [Theory]
        [InlineData(19)]
        [InlineData(709)]
        public void Should_return_a_single_post(int value)
        {
            var post = PostService.GetPostById(value);

            Assert.Equal(value, post.PostId);
        }
    }
}
