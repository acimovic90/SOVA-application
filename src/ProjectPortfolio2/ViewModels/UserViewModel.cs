using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;

namespace ProjectPortfolio2.ViewModels
{
    public class UserViewModel
    {
        public string Displayname { get; set; }
        public int Age { get; set; }
        public DateTime ?CreationDate { get; set; }
        public string Location { get; set; }
        public List<Post> Posts { get; set; }
    }
}