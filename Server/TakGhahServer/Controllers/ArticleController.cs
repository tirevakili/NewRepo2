
using GhorfeDar.DataLayer.Entities.Articles;
using GhorfeDar.Shared.Dtos.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakGhahCore.Repostiory;
using TakGhahCore.Service;

namespace GhorfeDar.Api.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ArticleController : Controller
    {
        private IUserService _context;
        public ArticleController(IUserService context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("/GetArticleID/{id}")]
        public IActionResult GetArticleID([FromRoute] int id)
        {
            var res = _context.GetArticleID(id);
            if (res == null) { return BadRequest("پیدا نشد"); }
            return Json(res);
        }
        
        [AllowAnonymous]
        [HttpGet("/GetAllCategoryArticle/{id}")]
        public async Task<IActionResult> GetAllCategoryArticle(int id)
        {
            var res=await _context.GetArticleCateGoryID(id);
            if (res == null) { return NotFound(); } 
            return Json(res);
        }

        [AllowAnonymous]
        [HttpGet("/GetCategoryArticleID/{id}")]
        public IActionResult GetCategoryArticleID(int id)
        {
            var res =  _context.GetArticlesCategoryID(id);
            if (res == null) { return NotFound(); }
            return Ok(res);
        }

        [HttpPost("/AddArticle")]
        public async Task<IActionResult> AddArticle([FromBody] ArticleViewModel article)
        {
            var ar = new Article()
            {
                ArticleDescription = article.ArticleDescription,
                ArticleName = article.ArticleName,
                KeyArticle = article.KeyArticle,
                TitleArticle = article.TitleArticle,
                ArticlesCategory_ID=article.ArticlesCategory_ID
            };
            var res =await _context.AddArticle(ar);
            if (res == null) { return BadRequest("اضافه نشد ..."); }
            return Json(res);
        }



        #region CategoryArticle
        [AllowAnonymous]
        [HttpGet("/GetAllCateGoryArticleID")]
        public async Task<IActionResult> GetAllCateGoryArticleID()
        {
            var res =await _context.GetAllArticlesCategory();
            if (res == null) { return BadRequest("پیدا نشد"); }
            return Json(res);
        }

    
        [HttpPost("/AddArticleCategory")]
        public async Task<IActionResult> AddArticleCategory([FromBody] ArticlesCategoryViewModel CategoryArticle)
        {
            var ar = new ArticlesCategory()
            {
                ArticlesCategoryDescription = CategoryArticle.ArticlesCategoryDescription,
                ArticlesCategoryName = CategoryArticle.ArticlesCategoryName,                
            };
            var res = await _context.AddArticlesCategory(ar);
            if (res == null) { return BadRequest("اضافه نشد ..."); }
            return Json(res);
        }


      
        [HttpPut("/UpdateArticle/{id}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] int id,[FromBody] ArticleViewModel article)
        {
            var ar = new Article()
            {
                ArticleDescription = article.ArticleDescription,
                ArticleName = article.ArticleName,
                KeyArticle = article.KeyArticle,
                TitleArticle = article.TitleArticle,
            };
            var res = await _context.UpdateArticle(id, ar);
            if (res == null) { return BadRequest("خطا ویرایش نشد ..."); }
            return Json(res);
        }


 
        [HttpPut("/UpdateArticleCategory/{id}")]
        public async Task<IActionResult> UpdateArticleCategory([FromRoute] int id,[FromBody] ArticlesCategoryViewModel CategoryArticle)
        {
          

            var ar = new ArticlesCategory()
            {
                ArticlesCategoryDescription = CategoryArticle.ArticlesCategoryDescription,
                ArticlesCategoryName = CategoryArticle.ArticlesCategoryName,
                ImageArticlesCategory= CategoryArticle.ImageArticlesCategory
            };
            var res = await _context.UpdateArticlesCategory(id, ar);
            if (res == null) { return BadRequest("خطا ویرایش نشد ..."); }
            return Json(res);
        }
        #endregion
    }
}
