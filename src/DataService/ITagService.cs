using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DataService
{
    public interface ITagService
    {
        int GetNumberOfTags();
        List<Tag> GetTags(int page, int pageSize);
        Tag GetTagById(int id);
    }
}
