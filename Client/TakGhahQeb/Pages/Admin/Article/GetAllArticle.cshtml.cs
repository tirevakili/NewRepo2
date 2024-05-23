using GhorfeDar.Shared.Dtos.Articles;
using GhorfeDarWeb.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayaTejaratDto.Options.API;

namespace TakGhahWeb.Pages.Admin.Article
{
    public class GetAllArticleModel : PageModel
    {
        HttpClient _httpClient = new();

        [BindProperty]
        public List<ArticleViewModel> ArticleViewModel { get; set; } = default!;


        public async Task OnGet(int id)
        {

            ArticleViewModel = await _httpClient.GetFromJsonAsync($"{APIs.BaseUrl}{APIs.GetAllCategoryArticleID}/{id}", AppJsonComponent.Default.ListArticleViewModel) ?? new();
        }
    }
}
