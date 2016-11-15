using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class RelatedPost
    {
        public int Score { get; set; }
        [Key]
        public string Title { get; set; }
       

        
    }
}
