using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class TagService : ITagService
    {
        public List<Post> GetPostsByTag(int id)
        {
            throw new NotImplementedException();
        }

        public Tag GetTagById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetTags(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
