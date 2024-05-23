
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhorfeDar.DataLayer.Entities.Articles
{
    public class ArticleImage
    {
        [Key]
        public int ArticleImageID { get; set; }

        public string? Images { get; set; }

        [ForeignKey("Articles")]
        public int Article_ID { get; set; }


        #region Relation
        public virtual Article? Articles { get; set; }
        #endregion
    }
}
