﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostModel.Models
{
    public class Category
    {   public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Childrens { get; set; }
       public List<Post> Posts { get; set; }
    }
}