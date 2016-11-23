using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;
using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio2.ViewModels.Templates.Tags;

namespace ProjectPortfolio2.ViewModels
{
    public class ListOfTagsModelFactory
    {
        public static ListOfTagsViewModel Map(List<Tag> tags, IUrlHelper url)
        {
            var tagsList = new List<TagViewModel>();

            foreach (var tag in tags)
            {
                var tmp = TagModelFactory.Map(tag, url);
                tagsList.Add(tmp);
            }

            return new ListOfTagsViewModel
            {
                Tags = tagsList
            };
        }
    }
}
