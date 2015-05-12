using GreensheetExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreensheetExercise.Controllers
{
    public class HomeController : Controller
    {
        private GreensheetCaretoriesService categoriesService = new GreensheetCaretoriesService();
        //
        // GET: /Categories/
        public ActionResult Index()
        {
            IEnumerable<Category> categories = categoriesService.GetMainCategories();
            return View(categories);
        }

        public ActionResult SubCategorySelection(int parentCategoryId)
        {

            IEnumerable<Category> categories = categoriesService.GetAllChildCategories(parentCategoryId);
            SubCategoryForm formModel = new SubCategoryForm();
            formModel.SubCategories = categories;

            return View(formModel);
        }

        [HttpPost]
        public ActionResult SubCategorySelection(SubCategoryForm subCategoryForm)
        {
            if (ModelState.IsValid)
            {


                return RedirectToAction("SubCategories", new { parentId = subCategoryForm.ParentCategoryID, childId = subCategoryForm.SelectedCategoryID });
            }
            subCategoryForm.SubCategories = categoriesService.GetAllChildCategories(subCategoryForm.ParentCategoryID);
            return View(subCategoryForm);
        }

        public ActionResult SubCategories(int parentId, int childId)
        {
            SubCategoriesModel model = new SubCategoriesModel();
            model.SelectedCategory = categoriesService.GetCategory(childId);
            model.ParentCategory = categoriesService.GetCategory(parentId);
            model.ChildCategories = categoriesService.GetAllChildCategories(childId);

            return View(model);
        }
    }
}
