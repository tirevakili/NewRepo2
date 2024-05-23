
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhorfeDar.DataLayer.Entities.Articles
{
    public class Article
    {
        #region ProductEntity
        [Key]
        public int Article_ID { get; set; }
        [Required]
        public string? ArticleName { get; set; }
        [Required]
        public string? ArticleDescription { get; set; }

        [ForeignKey("ArticlesCategorys")]
        public int ArticlesCategory_ID { get; set; }

        public string? TitleArticle { get; set; }


        public string? KeyArticle { get; set; }




        #endregion

        #region Relation             
        public virtual ArticlesCategory? ArticlesCategorys { get; set; }
        public virtual List<ArticleImage>? ArticleImages { get; set; }
        #endregion
    }
}
