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
        public int GetNumberOfTags()
        {
            using (var db = new SovaContext())
            {
                return db.Tags
                    .Count();
            }
        }

        public Tag GetTagById(int id)
        {
            using (var db = new SovaContext())
            {
                return db.Tags
                    .FirstOrDefault(t => t.Id == id);
            }
        }

        public List<Tag> GetTags(int page, int pageSize)
        {
            using (var db = new SovaContext())
            {
                return db.Tags
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }
    }
}
