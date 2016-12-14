﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models;
using ProjectPortfolio2.ViewModels.Partials;

namespace ProjectPortfolio2.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Displayname { get; set; }
        public int? Age { get; set; }
        public DateTime ?CreationDate { get; set; }
        public string Location { get; set; }
        public int Active { get; set; } //Just added
        public List<PostListViewModel> Posts { get; set; }
        public List<PostListViewModel> FavouritePosts { get; set; }
    }
}