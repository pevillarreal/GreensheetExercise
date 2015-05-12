using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreensheetExercise.Models
{
    public class SubCategoriesModel
    {
        public Category ParentCategory { get; set; }
        public Category SelectedCategory { get; set; }
        public IList<Category> ChildCategories { get; set; }
    }
}