using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public ICollection<Post> FavouritePosts { get; set; }



    }
}
