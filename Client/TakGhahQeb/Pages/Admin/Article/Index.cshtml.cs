using GhorfeDar.Shared.Dtos.Articles;
using GhorfeDarWeb.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayaTejaratDto.Options.API;

namespace TakGhahWeb.Pages.Admin.Article
{
    public class IndexModel : PageModel
    {
        HttpClient _httpClient=new();

        [BindProperty]
        public List<ArticlesCategoryViewModel> ArticlesCategoryViewModel { get; set; } = default!;


        public async Task OnGet()
        {

            ArticlesCategoryViewModel= await _httpClient.GetFromJsonAsync($"{APIs.BaseUrl}{APIs.GetArticleCategory}",AppJsonComponent.Default.ListArticlesCategoryViewModel)??new();
        }
    }
}
