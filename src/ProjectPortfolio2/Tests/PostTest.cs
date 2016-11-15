using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using ProjectPortfolio2.Controllers;
using Xunit;

namespace ProjectPortfolio2.Tests
{
    public class PostTest
    {
        private static readonly IPostService _postService = new PostService();
        private static readonly PostsController _postsController = new PostsController(_postService);

        [Theory]
        [InlineData(19)]
        [InlineData(709)]
        public void Should_return_a_single_post(int value)
        {
            var post = _postService.GetPostById(value);

            Assert.Equal(value, post.PostId);
        }


    }
}
