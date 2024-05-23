using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhorfeDar.Shared.Dtos.Articles
{
    public class ArticlesCategoryViewModel
    {
        #region CategoryEntity
   
        public int ArticlesCategory_ID { get; set; }
      
        public string? ArticlesCategoryName { get; set; }
       
        public string? ArticlesCategoryDescription { get; set; }

        public string? ImageArticlesCategory { get; set; }
        #endregion

        #region Relation     

       // public virtual List<ArticleViewModel>? Articles { get; set; }
        #endregion
    }
}
