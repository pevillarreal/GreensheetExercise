using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GreensheetExercise.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("parentCategoryId")]
        public int ParentCategoryId { get; set; }
        [JsonProperty("logoUrl")]
        public string LogoUrl { get; set; }
    }
}