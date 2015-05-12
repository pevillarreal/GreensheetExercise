using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreensheetExercise.Models
{
    public class SubCategoryForm
    {
        public int ParentCategoryID { get; set; }
        public IEnumerable<Category> SubCategories { get; set; }
        [Required(ErrorMessage = "A category must be selected")]
        [Display(Name = "Category")]
        public int? SelectedCategoryID { get; set; }
    }
}