using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhorfeDar.Shared.Dtos.Articles;

namespace TakGhahCore.DTOs
{
    public class ArticleImageViewModel
    {

        public int ArticleImageID { get; set; }

        public string? Images { get; set; }


        public int Article_ID { get; set; }


        #region Relation
        public virtual ArticleViewModel? Articles { get; set; }
        #endregion
    }
}
