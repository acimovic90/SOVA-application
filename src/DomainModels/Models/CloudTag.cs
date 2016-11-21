using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class CloudTag
    {
        [Column("word")]
        public string Word { get; set; }
        [Column("count")]
        public decimal Count { get; set; }

    }
}
