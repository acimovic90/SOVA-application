using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataService
{
    public interface ITagService
    {
        List<Tag> GetTags(int page, int pageSize);
        Tag GetTagById(int id);
        List<Post> GetPostsByTag(int id);
    }
}
