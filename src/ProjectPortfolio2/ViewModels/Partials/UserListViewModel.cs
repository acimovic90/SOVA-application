using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPortfolio2.ViewModels.Partials
{
    public class UserListViewModel
    {
        public int Id { get; set; }
        public string Displayname { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }
        public string Url { set; get; }
    }
}
