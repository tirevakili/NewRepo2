using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakGhahCore.DTOs;

namespace GhorfeDar.Shared.Dtos.Articles
{
    public class ArticleViewModel
    {
        #region ProductEntity
     
        public int Article_ID { get; set; }
 
        public string? ArticleName { get; set; }
      
        public string? ArticleDescription { get; set; }

        public int ArticlesCategory_ID { get; set; }

        public string? TitleArticle { get; set; }


        public string? KeyArticle { get; set; }




        #endregion

        #region Relation             
        //public virtual ArticlesCategoryViewModel? ArticlesCategorys { get; set; }
        public virtual List<ArticleImageViewModel>? ArticleImages { get; set; }
        #endregion
    }
}
