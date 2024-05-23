using GhorfeDar.Core.DTOs.UserModel;

using GhorfeDar.DataLayer.Entities.Articles;

using GhorfeDar.DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakGhahDataLayer.Context;

namespace TakGhahCore.UOF
{
    public class UnitOfWork : IDisposable
    {
        private TakGhahContext _dB;
        public UnitOfWork(TakGhahContext dB)
        {
            _dB = dB;
        }








        #region FindCategoryArticleID
      
        public ArticlesCategory FindCategoryArticleID(int categoryID)
        {
            return _dB.ArticlesCategories.FirstOrDefault(u => u.ArticlesCategory_ID == categoryID)!;
        }
        public ArticleImage GetArticleName(int imageID)
        {
            return _dB.ArticleImages.FirstOrDefault(u => u.ArticleImageID == imageID)!;
        }
        public async Task<ArticleImage> UpdateArticleImage(int imageID, string productImage)
        {
            var responce = await _dB.ArticleImages.FirstOrDefaultAsync(u => u.ArticleImageID == imageID)!;
            if (responce != null)
            {
                responce.Images = productImage;
                _dB.Update(responce);
                await _dB.SaveChangesAsync();
            }
            return responce!;
        }
        public ArticleImage DeleteArticleImageName(int imageID)
        {
            var res = _dB.ArticleImages.Single(u => u.ArticleImageID == imageID)!;
            if (res != null)
            {
                _dB.Remove(res);
                _dB.SaveChanges();
            }
            return res!;
        }
        #endregion



   



        public async Task SaveChangeAsync()
        {
            await _dB.SaveChangesAsync();
        }
        public void Save()
        {
            _dB.SaveChanges();
        }
        public void Dispose()
        {
            _dB.Dispose();
        }
    }
}
