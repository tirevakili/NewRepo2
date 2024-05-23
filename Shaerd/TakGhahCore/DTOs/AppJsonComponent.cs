
using GhorfeDar.Shared.Dtos.Articles;
using System.Text.Json.Serialization;
using TakGhahCore.DTOs.UserModel;

namespace GhorfeDarWeb.Core.Dtos
{

    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(LoginViewModel))]
    [JsonSerializable(typeof(ArticlesCategoryViewModel))]
    [JsonSerializable(typeof(List<ArticlesCategoryViewModel>))]
    [JsonSerializable(typeof(ArticleViewModel))]
    [JsonSerializable(typeof(List<ArticleViewModel>))]
    public partial class AppJsonComponent : JsonSerializerContext
    {

    }
}
