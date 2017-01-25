using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddPost.Models
{
    public class Category
    {
        public string Name { get; set; }
        public List<Category> Childrens { get; set; }
        public Category Parent { get; set; }
    }
}