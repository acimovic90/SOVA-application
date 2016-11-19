using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2.ViewModels.Templates;

namespace ProjectPortfolio2.ViewModels.ModelFactories.Comments
{
    public class CommentModelFactory
    {
        public static CommentViewModel Map(Comment comment, IUrlHelper url) //
        {

            return new CommentViewModel
            {
                Id = comment.Id,
                Url = url.Link(Config.CommentRoute, new {id = comment.Id}),
                Score = comment.Score,
                Text = comment.Text,
                CreateDate = comment.CreateDate
            };
        }
    }
}
