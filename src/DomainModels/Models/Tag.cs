using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    [Table("postTags")]
    public class Tag
    {
        [Key]
        public string Title { get; set; }

        public string Url = null;
    }
}
