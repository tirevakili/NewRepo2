using GhorfeDar.DataLayer.Entities.Articles;
using GhorfeDar.DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakGhahCore.DTOs.UserModel;
using TakGhahCore.Extiations;
using TakGhahCore.Repostiory;
using TakGhahDataLayer.Context;
using TakGhahDataLayer.Entites.Users;

namespace TakGhahCore.Service
{
    public class UserService : IUserService
    {
        private TakGhahContext _dB=default!;

        public UserService(TakGhahContext dB)
        {
                _dB = dB;   
        }

        #region User     
        public async Task<MainRespanse> RegisterUser(User register)
        {
            var response = new MainRespanse();
            try
            {
                if (await AnyUserPhone(register.Phone!))
                {
                    var res = await _dB.Users.FirstOrDefaultAsync(u => u.Phone == register.Phone);
                    res!.Code = register?.Code;
                    _dB.Users.Update(res!);
                    await _dB.SaveChangesAsync();
                    response.IsSuccess = false;
                }
                else
                {
                    await _dB.Users.AddAsync(register);
                    await _dB.SaveChangesAsync();
                    response.IsSuccess = true;

                }


            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            //await _dB.DisposeAsync();
            return response;
        }

        public async Task<bool> AnyUserPhone(string phone)
        {
            if (_dB.Users.Any(e => e.Phone!.ToLower() == phone.ToLower()))
            {
                return await Task.FromResult(true);
            }
            // await _dB.DisposeAsync();
            return await Task.FromResult(false);
        }
        public UserRole GetUserRole(int userID)
        {
            return _dB.UserRoles.Where(a => a.UserID == userID).FirstOrDefault()!;
        }
        public async Task<MainRespanse> AddUserRole(UserRole userRole)
        {
            var response = new MainRespanse();
            try
            {
                if (await AnyRoleID(userRole.UserID!))
                {
                    response.IsSuccess = false;
                }
                else
                {
                    await _dB.UserRoles.AddAsync(userRole);
                    await _dB.SaveChangesAsync();
                    //_dB.Dispose();
                    response.IsSuccess = true;
                }


            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
        public async Task<UserRole> UpdateUserRole(UserRole userRole, int userID)
        {
            var res = await _dB.UserRoles.FirstOrDefaultAsync(a => a.UserID == userID);
            if (res != null)
            {
                res.RoleName = userRole.RoleName;
                _dB.UserRoles.Update(res);
                await _dB.SaveChangesAsync();
            }
            return userRole!;
        }

        public async Task<bool> AnyRoleID(int userID)
        {
            if (_dB.UserRoles.Any(e => e.UserID == userID))
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        public async Task<User> UpdateUser(int userID, User user)
        {
            var us = _dB.Users.Where(us => us.UserID == userID).FirstOrDefault();
            try
            {

                if (us != null)
                {
                    us.FullName = user.FullName;
                    us.UserName = user.UserName;           
                    us.ProfileImageName = user.ProfileImageName;
                    us.BirthDate = user.BirthDate;
                    us.Description = user.Description;
                    _dB.Users.Update(us);
                    await _dB.SaveChangesAsync();
                }
            }
            catch
            {


            }
            return us!;
        }



        public async Task<int> GetCountUser()
        {
            return await _dB.Users.CountAsync();
        }
        public async Task<List<User>> GetAllUser()
        {
            return await _dB.Users.ToListAsync();
        }

        public User GetUserID(int userID)
        {
            return _dB.Users.Where(u => u.UserID == userID).Include(s => s.UserRoles).FirstOrDefault()!;

        }
     



        public User AuthenticationUser(LoginViewModel login)
        {
            return _dB.Users.Include(a => a.UserRoles).FirstOrDefault(u => u.Email == login.Email && u.Code == login.Code)!;
        }
      
        public async Task<User> ActiveUser(string phone)
        {
            var res = await _dB.Users.FirstOrDefaultAsync(a => a.Phone == phone);
            if (res != null)
            {
                res.Code = Guid.NewGuid().ToString();
            }
            await _dB.SaveChangesAsync();
            _dB.Users.Update(res!);
            return res!;
        }


        #endregion

        #region Atrical
        public ArticleImage AddArticleImage(ArticleImage article)
        {
            _dB.ArticleImages.Add(article);
            _dB.SaveChanges();
            return article!;
        }

        public async Task<List<Article>> GetArticleImages(int articleID)
        {
            return await _dB.Articles.Where(a => a.Article_ID == articleID)
                .AsNoTracking()
                 .AsQueryable().Include(a => a.ArticleImages).ToListAsync();
        }

        public async Task<Article> UpdateArticle(int articleID, Article article)
        {
            var pr = _dB.Articles.Where(us => us.Article_ID == articleID).FirstOrDefault();
            try
            {
                if (pr != null)
                {
                    pr!.ArticleName = article.ArticleName;
                    pr.ArticleDescription = article.ArticleDescription;
                    pr.TitleArticle = article.TitleArticle;
                    pr.KeyArticle = article.KeyArticle;
                    _dB.Articles.Update(pr);
                    await _dB.SaveChangesAsync();
                }
            }
            catch
            {


            }
            return pr!;
        }

        public async Task<Article> AddArticle(Article article)
        {
            await _dB.Articles.AddAsync(article);
            await _dB.SaveChangesAsync();
            return article;
        }

        public ArticlesCategory GetArticlesCategoryID(int categoryArticleID)
        {
            return _dB.ArticlesCategories.Where(ca => ca.ArticlesCategory_ID == categoryArticleID).FirstOrDefault()!;
        }

        public async Task<List<ArticlesCategory>> GetAllArticlesCategory()
        {
            var res = await _dB.ArticlesCategories.ToListAsync();
            return res!;
        }

        public async Task<ArticlesCategory> AddArticlesCategory(ArticlesCategory categoryArticle)
        {
            await _dB.ArticlesCategories.AddAsync(categoryArticle);
            await _dB.SaveChangesAsync();
            return categoryArticle;
        }

        public async Task<ArticlesCategory> UpdateArticlesCategory(int categoryID, ArticlesCategory categoryArticle)
        {
            var ca = _dB.ArticlesCategories.Where(c => c.ArticlesCategory_ID == categoryID).FirstOrDefault();
            try
            {

                if (ca != null)
                {
                    ca!.ArticlesCategoryName = categoryArticle.ArticlesCategoryName;
                    ca.ArticlesCategoryDescription = categoryArticle.ArticlesCategoryDescription;
                    ca.ImageArticlesCategory = categoryArticle.ImageArticlesCategory;
                    _dB.ArticlesCategories.Update(ca);
                    await _dB.SaveChangesAsync();
                }
            }
            catch
            {


            }
            return ca!;
        }

        public ArticlesCategory DeleteArticlesCategory(int categoryArticleID)
        {
            var CategoryDelete = _dB.ArticlesCategories.Single(p => p.ArticlesCategory_ID == categoryArticleID);
            if (CategoryDelete != null)
            {
                _dB.ArticlesCategories.Remove(CategoryDelete);
                _dB.SaveChanges();
            }
            return CategoryDelete!;
        }
        public async Task<List<Article>> GetArticleCateGoryID(int categoryID)
        {
            return await _dB.Articles.Where(a => a.ArticlesCategory_ID == categoryID).Include(a => a.ArticleImages).ToListAsync();
        }
        public ArticlesCategory GetCategoryArticleID(int CategoryArticleID)
        {
            return _dB.ArticlesCategories.FirstOrDefault(a => a.ArticlesCategory_ID == CategoryArticleID) ?? new();
        }
        public Article GetArticleID(int ArticleID)
        {
            var res = _dB.Articles.Where(ca => ca.Article_ID == ArticleID)
             .Include(a => a.ArticleImages)
             .FirstOrDefault()!;
            return res!;
        }
        #endregion
    }
}
