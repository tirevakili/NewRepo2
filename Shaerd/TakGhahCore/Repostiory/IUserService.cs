using GhorfeDar.DataLayer.Entities.Articles;
using GhorfeDar.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakGhahCore.DTOs.UserModel;
using TakGhahCore.Extiations;
using TakGhahDataLayer.Entites.Users;

namespace TakGhahCore.Repostiory
{
    public interface IUserService
    {
        #region User
        Task<MainRespanse> RegisterUser(User register);
        Task<User> ActiveUser(string phone);
        User AuthenticationUser(LoginViewModel login);
        Task<User> UpdateUser(int userID, User user);
        User GetUserID(int userID);
        Task<List<User>> GetAllUser();
        Task<int> GetCountUser();
       

        #endregion

        #region UserRole
        UserRole GetUserRole(int userID);
        Task<MainRespanse> AddUserRole(UserRole userRole);
        Task<UserRole> UpdateUserRole(UserRole userRole, int userID);
        #endregion

        #region Articals
        ArticleImage AddArticleImage(ArticleImage article);
        Task<List<Article>> GetArticleImages(int articleID);
        Task<Article> UpdateArticle(int articleID, Article article);
        Task<Article> AddArticle(Article article);
        Article GetArticleID(int ArticleID);
        ArticlesCategory GetCategoryArticleID(int CategoryArticleID);
        Task<List<Article>> GetArticleCateGoryID(int categoryID);


        ArticlesCategory GetArticlesCategoryID(int categoryArticleID);
        Task<List<ArticlesCategory>> GetAllArticlesCategory();
        Task<ArticlesCategory> AddArticlesCategory(ArticlesCategory categoryArticle);
        Task<ArticlesCategory> UpdateArticlesCategory(int categoryID, ArticlesCategory categoryArticle);
        ArticlesCategory DeleteArticlesCategory(int categoryArticleID);
        #endregion
    }
}
