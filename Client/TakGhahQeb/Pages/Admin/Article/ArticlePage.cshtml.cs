using GhorfeDar.Shared.Dtos.Articles;
using GhorfeDarWeb.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayaTejaratDto.Options.API;

namespace TakGhahWeb.Pages.Admin.Article
{
    public class ArticlePageModel : PageModel
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
    }
}
