using GhorfeDar.Shared.Dtos.Articles;
using GhorfeDarWeb.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayaTejaratDto.Options.API;
using System.Text;

namespace TakGhahWeb.Pages.Admin.Article
{
    public class AddToCategoryArticleModel : PageModel
    {
        HttpClient _httpClient = new();

        private static int _page = 0;

        [BindProperty]
        public ArticleViewModel ArticleViewModel { get; set; } = default!;
        public void OnGet(int id)
        {
            _page = id;
        }

        public async Task<IActionResult> OnPost()
        {
            ArticleViewModel.ArticlesCategory_ID= _page;    
            var article = await _httpClient.PostAsync($"{APIs.BaseUrl}{APIs.AddArticle}", new StringContent(JsonConvert.SerializeObject(ArticleViewModel), Encoding.UTF8, "application/json")) ?? new();
            if (article.IsSuccessStatusCode)
            {
                return RedirectToPage("/admin/Article/index");
            }
            return Page();
        }


    }
}
