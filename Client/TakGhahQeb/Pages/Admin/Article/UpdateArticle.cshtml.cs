using GhorfeDar.Shared.Dtos.Articles;
using GhorfeDarWeb.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PayaTejaratDto.Options.API;
using System.Text;

namespace TakGhahWeb.Pages.Admin.Article
{
    public class UpdateArticleModel : PageModel
    {
        HttpClient _httpClient = new();
        private static int _page = 0;

        [BindProperty]
        public ArticleViewModel ArticleViewModel { get; set; } = default!;


        public async Task OnGet(int id)
        {
            ArticleViewModel = await _httpClient.GetFromJsonAsync($"{APIs.BaseUrl}{APIs.GetArticleID}{id}", AppJsonComponent.Default.ArticleViewModel) ?? new();
            _page = ArticleViewModel.Article_ID;
        }


        public async Task<IActionResult> OnPost()
        {
            
            var response = await _httpClient.PutAsync($"{APIs.BaseUrl}{APIs.UpdateArticle}{_page}", new StringContent(JsonConvert.SerializeObject(ArticleViewModel), Encoding.UTF8, "application/json"));


            // var ArticlesCategory = await _httpClient.PutAsJsonAsync($"{APIs.BaseUrl}{APIs.UpdateArticleCategoryID}{_page}", AppJsonComponent.Default.ArticlesCategoryViewModel) ?? new();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/admin/Article/index");
            }
            return Page();
        }
    }
}
