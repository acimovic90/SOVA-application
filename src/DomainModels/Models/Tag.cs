using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Tag
    {
        [Key]
        public string Title { get; set; }
    }
}
