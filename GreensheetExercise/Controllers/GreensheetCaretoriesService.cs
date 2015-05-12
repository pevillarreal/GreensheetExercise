using GreensheetExercise.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;

namespace GreensheetExercise.Controllers
{
    public class GreensheetCaretoriesService
    {
        private static readonly string CategoryUri = "http://api.thegreensheet.com/v2/category";
        private static readonly int MainCategoryId = 0;

        public IList<Category> GetAllChildCategories(int parentCategoryId)
        {
            IList<Category> allCategories = getAllCategories();
            IList<Category> results = new List<Category>(allCategories.Where(category => category.ParentCategoryId == parentCategoryId));

            return results;
        }

        public IList<Category> GetMainCategories()
        {
            return GetAllChildCategories(MainCategoryId);
        }

        public Category GetCategory(int categoryId)
        {
            IList<Category> allCategories = getAllCategories();
            IList<Category> results = new List<Category>(allCategories.Where(category => category.Id == categoryId));
            if (results.Count == 1)
                return results[0];

            return null;
        }

        public IList<Category> getAllCategories()
        {
            IList<Category> categories = MemoryCache.Default["cachedCategories"] as IList<Category>;
            if (categories == null)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    Task<String> response = httpClient.GetStringAsync(CategoryUri);
                    IList<Category> allCategories = JsonConvert.DeserializeObjectAsync<IList<Category>>(response.Result).Result;
                    MemoryCache.Default.Set("cachedCategories", allCategories, DateTime.Now.AddMinutes(10));
                    categories = allCategories;
                }
            }

            return categories;
        }
    }
}