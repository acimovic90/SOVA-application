using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using Microsoft.Extensions.Configuration;
using Xunit;
using Moq;
using ProjectPortfolio2.Controllers;

namespace ProjectPortfolio2.Tests
{
    public class CommentTest
    {
        [Fact]
        public void return_comment_id()
        {
            //int commentTestId = 52774; //

            //ICommentService _commentService = new CommentService();
            //var comment = _commentService.GetCommentById(commentTestId);

            //Assert.Equal(commentTestId, comment.Id);
            int commentTestId = 18728068;
            Mock<ICommentService> repo = new Mock<ICommentService>();
            CommentsController controller = new CommentsController(repo.Object);
            controller.Get(commentTestId);
            repo.Verify(r => r.GetCommentById(commentTestId));

        }
    }
}
