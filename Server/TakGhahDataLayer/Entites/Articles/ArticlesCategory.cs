using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhorfeDar.DataLayer.Entities.Articles
{
    public class ArticlesCategory
    {
        #region CategoryEntity
        [Key]
        public int ArticlesCategory_ID { get; set; }
        [Required]
        public string? ArticlesCategoryName { get; set; }
        [Required]
        public string? ArticlesCategoryDescription { get; set; }

        public string? ImageArticlesCategory { get; set; }
        #endregion

        #region Relation     

        public virtual List<Article>? Articles { get; set; }
        #endregion
    }
}
